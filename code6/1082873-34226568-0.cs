    public class BaseController : ApiController
    {
            public virtual Task<bool> CheckAccessAsync(string action, params string[] resources)
            {
                return Request.CheckAccessAsync(action, resources);
            }
    }
