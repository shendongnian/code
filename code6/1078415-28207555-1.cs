    public class VRouterConstraint : IRouteConstraint {
        public VRouterConstraint (string controllerId) {
            this.ControllerId= controllerId;
        }
        public string ControllerId{ get; set; }
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, IDictionary<string, object> values, RouteDirection routeDirection) {
            object deviceIdObject;
            if (!values.TryGetValue(routeKey, out deviceIdObject)) {
                return false;
            }
            string deviceId = deviceIdObject as string;
            if (deviceId == null) {
                return false;
            }
            bool match = false;
            using (VRouterDbContext vRouterDb = new VRouterDbContext ()) {
                match = vRouterDb.DeviceServiceAssociations
                    .AsNoTracking()
                    .Where(o => o.ControllerId == this.ControllerId)
                    .Any(o => o.AssoicatedDeviceId == deviceId);
            }
            return match;
        }
    }
