    using Autofac.Integration.SignalR;
    using Microsoft.AspNet.SignalR.StockTicker;
    public static class RegisterHubs
    {
        public static void Start() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<StockTicker>()
                .WithParameter(ResolvedParameter.ForNamed("StockTickerContext"))
                .As<IStockTicker>()
                .SingleInstance();
            builder.Register(c => c.Resolve<IConnectionManager>().GetHubContext<StockTickerHub>().Clients)
                .Named<IHubConnectionContext>("StockTickerContext");
            var container = builder.Build();
            var resolver = new AutofacDependencyResolver(container);
            var config = new HubConfiguration { Resolver = resolver };
            App.MapSignalR(config);
        }
    }
