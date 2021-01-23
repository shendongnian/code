    class SessionVariables {
        static class Cache<T> where T : ISessionVariable, new() {
            public static readonly ISessionVariable Value = new T();
        }
        ISessionVariable Get<T>() where T : ISessionVariable, new() {
            return Cache<T>.Value;
        }
    }
