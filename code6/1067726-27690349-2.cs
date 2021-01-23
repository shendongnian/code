    public class HomeController : Controller
    {
        public async Task<JsonResult> CallToWebApi()
        {
            return this.Content(
                await new WebApiCaller().GetObjectsAsync(),
                "application/json"
            );
        }
    }
    
    public class WebApiCaller
    {
        readonly string uri = "your url";
    
        public async Task<string> GetObjectsAsync()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(uri);
            }
        }
    }
