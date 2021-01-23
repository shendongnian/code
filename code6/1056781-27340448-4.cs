    public class SomeMvcController : Controller
    {
        private readonly IApiCaller _apiCaller;
    
        public SomeClass(IApiCaller apiCaller)
        {
            _apiCaller = apiCaller;
        }
    
        public async Task<string> GetStringFromWebApi()
        {
            string result = await _apiCaller.Get<string>("myApiUrl");
            return result;
        }
    }
