    public static void MyServiceExtensions
    {
        public static object SharedMethod(this IServicBase service, object request)
        {
            var sharedDep = service.TryResolve<ISharedDep>();
            return sharedDep.SharedMethodWithRequestCtx(request, service.Request);
        }
    }
