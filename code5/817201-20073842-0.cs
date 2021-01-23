    class SessionVariables
    {
        static class Cache<T>
        {
            public static ISessionVariables Value;
        }
    
        ISessionVariables Get<T>() where T : ISessionVariable, new()
        {
            return Cache<T>.Value ?? (Cache<T>.Value = new T());
        }
    }
