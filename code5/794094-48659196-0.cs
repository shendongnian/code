    namespace tWorks.Alfa.Modules.ModuleRestApiService
    {
        public class AppHost : AppSelfHostBase
        {
            public AppHost() : base("HttpListener Self-Host", typeof(Services.AlfaProService.AlfaProService).Assembly)
            {
            }
            public override void Configure(Funq.Container container) { }
            public override RouteAttribute[] GetRouteAttributes(Type requestType)
            {
                var routes = base.GetRouteAttributes(requestType);
                if (requestType.FullName.Contains(nameof(Services.AlfaConnectService.AlfaConnectService)))
                {
                    routes.Each(x => x.Path = "/alfaconnect" + x.Path);
                }
                else if (requestType.FullName.Contains(nameof(Services.AlfaProService.AlfaProService)))
                {
                    routes.Each(x => x.Path = "/alfapro" + x.Path);
                }
                return routes;            
            }
        }
    }
