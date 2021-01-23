    public class BaseApiController : ApiController
    {
        protected override OkResult Ok()
        {
            return new OkJsonPatchResult(this);
        }
    }
