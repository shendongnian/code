    public static class ClassExtenstions
    {
        public static Providers? GetServiceProvider<T>(this T cls) where T : class
        {
            var attribute = typeof(T).GetCustomAttributes(typeof (ServiceProvider), inherit: false).FirstOrDefault() as ServiceProvider;
            return attribute != null ? attribute.CustomProvider : (Providers?)null;
        }
    }
