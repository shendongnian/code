    public static class UnityExtensions
    {
        public static T TryResolve<T>(this IUnityContainer container)
        {
            if (container.IsRegistered<T>())
                return container.Resolve<T>();
    
            return default(T);
        }
    }
    // TryResolve returns null if the type is not configured
    IBus = container.TryResolve<IBus>();
