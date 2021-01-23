public class EnController : Controller{
            public EnController(IHttpContextAccessor myHttpAccessor)
            {
                myHttpAccessor.HttpContext.Response.Headers.Add("Content-Language", "en-US");
            }
           ... more methods here... 
}
