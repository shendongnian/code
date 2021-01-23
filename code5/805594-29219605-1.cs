        public abstract class ControllerBase : ApiController
        {
            [Route]
            public IHttpActionResult Get()
            {
                return this.Ok(this.GetType().FullName);
            }
        }
