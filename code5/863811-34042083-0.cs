    class Startup
    {
       private readonly IDependencyResolver _resolver;
       
       public Startup(IDependencyResolver resolver)
       {
    		_resolver = resolver;
       }
       
       public void Configuration(IAppBuilder app)
       {
           app.MapSignalR(new HubConfiguration { Resolver = _resolver; });
       }
    }
    class Program
    {
        static void Main(string[] args)
        {
    		Startup startup = new Statrtup(new MyResolver());
            using (WebApp.Start("http://localhost:8080", p => { startup.Configuration(p); }))
            {
                Console.WriteLine("Server running on {0}", url);
                Console.ReadLine();
            }
        }
    }
