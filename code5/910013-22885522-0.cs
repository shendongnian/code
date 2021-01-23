    [RoutePrefix("api/foo")]
    public class FooController : ApiController
    {
        [HttpPost]
        [Route("bar")]
        public void Bar(string foo, string bar)
        {
            MyMailer myMailer = new MyMailer();
            myMailer.MyAction(foo, bar).Send();
        }
    }
