    [Authorize]
    public class MyApiController : ApiController
    {
        [AllowAnonymous]
        public string GetData() 
        {
           
        }
    }
