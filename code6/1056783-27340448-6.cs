    public class SomeMvcController : Controller
    {
        private readonly IApiCaller _apiCaller;
        // use this if you don't want to rely on Dependency Injection, OR
        // if you don't use Ioc container for now.     
        public SomeClass(): this(new ApiCaller())
        {
        }
       
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
