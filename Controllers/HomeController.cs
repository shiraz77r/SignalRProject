using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRProject.Hubs;
using SignalRProject.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<NotificationsHub> _notificationsContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<NotificationsHub> notificationsContext)
        {
            _logger = logger;
            _notificationsContext = notificationsContext;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            await _notificationsContext.Clients.All.SendAsync("Broadcast", $"Privacy page visited at: {DateTime.UtcNow}");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
