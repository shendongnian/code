    abstract class BaseHandler // HttpHandler
    {
        public abstract Task MyMethodAsync();
    }
    
    abstract class Handler : BaseHandler // MessageHandler
    {
        public Handler InnerHandler { get; set; }
    
        public override Task MyMethodAsync()
        {
            if (this.InnerHandler != null)
                return this.InnerHandler.MyMethodAsync();
            else
                return Task.FromResult<object>(null);
        }
    }
    
    class Handler1 : Handler
    {
        public override async Task MyMethodAsync()
        {
            Console.WriteLine("Method_1"); //alias to request
            await base.MyMethodAsync();
            Console.WriteLine("Finished Method_1");  //alias to response
        }
    }
    
    class Handler2 : Handler
    {
        public override async Task MyMethodAsync()
        {
            Console.WriteLine("Method_2"); //alias to request
            await base.MyMethodAsync();
            Console.WriteLine("Finished Method_2");  //alias to response
        }
    }
    
    class LastHandler : Handler
    {
        public override async Task MyMethodAsync()
        {
            // Does nothing
            await base.MyMethodAsync();
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Handler> handlers = new List<Handler>();
            // You do this when you add the handler to config
            handlers.Add(new Handler1());
            handlers.Add(new Handler2());
    
            // This part is done by HttpClientFactory
            Handler pipeline = new LastHandler();
    
            handlers.Reverse();
            foreach (var handler in handlers)
            {
                handler.InnerHandler = pipeline;
                pipeline = handler;
            }
    
            pipeline.MyMethodAsync().Wait();
        }
    }
