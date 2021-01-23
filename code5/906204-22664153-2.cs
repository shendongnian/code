    [RoutePrefix("")]
    public class TestController : BaseApiController
    {
        public override string GetVersion();
        {
            return "Version 1.0.0.0";
        }
    }
