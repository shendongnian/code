     public class MyHandler : Ninject.Web.HttpHandlerBase
    {
        [Inject]
        public IHelloService HelloService { get; set; }
        protected override void DoProcessRequest(HttpContext context)
        {
            context.Response.Write(HelloService.Hello());
        }
        public override bool IsReusable { get { return true; } }
    }
