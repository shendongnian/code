    public class CustomerController : ApiController
    {
        [HttpGet]
        [GET("api/customer/{id}/files")]
        public HttpResponseMessage Get(int id)
        {
    	//code
        }
    
        [HttpGet]
        [GET("api/customer/{id}/files/{fileId}")]
        public HttpResponseMessage Get(int id, int fileId)
        {
    	//code
        }
    }
