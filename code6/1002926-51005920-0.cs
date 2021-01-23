    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            // This works !
            ViewBag.Title = GetAsync().Result;
            // This cause deadlock even with "ConfigureAwait(false)" !
            ViewBag.Title = PingAsync().Result;
            return View();
        }
        public async Task<string> GetAsync()
        {
            var uri = new Uri("http://www.google.com");
            return await new HttpClient().GetStringAsync(uri).ConfigureAwait(false);
        }
        public async Task<string> PingAsync()
        {
            var pingResult = await new Ping().SendPingAsync("www.google.com", 3).ConfigureAwait(false);
            return pingResult.RoundtripTime.ToString();
        }
    }
