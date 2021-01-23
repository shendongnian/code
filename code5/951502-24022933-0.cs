    public class ServiceA : Service
    {
        public AResponse Get(ARequest request)
        {
            // Request is ok in entry point.
            // Use ResolveService<T> here not TryResolve<T>
            var srvResp = ResolveService<ServiceB>().Get(new BRequest{ ... });
        }
    }
