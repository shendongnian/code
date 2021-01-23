    public class ActivityController : ApiController
    {
        // POST api/activity
        public async Task<HttpResponseMessage> Post(HttpRequestMessage request)
        {
             var jsonString = await request.Content.ReadAsStringAsync();
    
             return new HttpResponseMessage();
        }
    }
