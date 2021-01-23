    public class SimpleMiddleWare:OwinMiddleware
    {
        public SimpleMiddleWare(OwinMiddleware next) : base(next)
        {
        }
        public override async Task Invoke(IOwinContext context)
        {
            Debug.WriteLine("Begin Request");//Add begin request logic
            await Next.Invoke(context);
            Debug.WriteLine("End Request");//Add end request logic
        }
    }
