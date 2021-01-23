    public class HomeController : Controller {
    
        public async Task<JsonResult> CallToWebApi() {
    
            return Json( new {
                data = await new WebApiCaller().GetObjectsAsync()
                }
            );
        }
    }
    
    public class WebApiCaller {
    
        readonly string uri = "your url";
    
        public async Task<YourObject> GetObjectsAsync() {
    
            using (HttpClient httpClient = new HttpClient()) {
    
                return JsonConvert.DeserializeObject<List<YourObject>>(
                    await httpClient.GetStringAsync(uri)    
                );
            }
        }
    }
