    public void ConfigureServices(IServiceCollection services)
    {
        services.AddEntityFramework(Configuration)
            .AddSqlServer()
            .AddDbContext<VRouterDbContextt>();
        //...
     }
    // Note: I added the DbContext here (and yes, this does in fact work)...
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
         ILoggerFactory loggerfactory, VRouterDbContext context)
    {
        // ....
         app.UseMvc(routes =>
         {
             routes.MapRoute(
                 name: "VRoute_" + "Example",
                 template: "Api/VRouter/{deviceId}/{action}",
                 defaults: new { controller = "Example"},
                 constraints: new { deviceId = new VRouterConstraint(context, "Example")}
            });
    }
    public class VRouterConstraint : IRouteConstraint {
        public VRouterConstraint (VRouterDbContext context, string controllerId) {
           this.DbContext = context;
           this.ControllerId = controllerId;
        }
        private VRouterDbContext DbContext {get; set;}
        public string ControllerId{ get; set; }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, 
            IDictionary<string, object> values, RouteDirection routeDirection) {
            object deviceIdObject;
            if (!values.TryGetValue(routeKey, out deviceIdObject)) {
                return false;
            }
            string deviceId = deviceIdObject as string;
            if (deviceId == null) {
                return false;
            }
            bool match = DbContext.DeviceServiceAssociations
                .AsNoTracking()
                .Where(o => o.ControllerId == this.ControllerId)
                .Any(o => o.AssoicatedDeviceId == deviceId);
            return match;
        }
    }
