    public class MyController : ApiController
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            this.Configuration.Filters.Add(new VoidActionFilter());
        }
    }
