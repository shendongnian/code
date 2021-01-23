    public class Proxy
    {
        public async Task<ExampleDto> GetExample(int id)
        {
            var client=new HttpClient();
            //set some auth here
            //set other headers
            var response = client.GetAsync(
        	     string.Format("/api/restserviceexample/{0}", id))
            	    .Result.Content.ReadAsAsync<ExampleDto>();
            return await response;
        }
    }
