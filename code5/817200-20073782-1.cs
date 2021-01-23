    internal class SessionVariables
    {
        private readonly ConcurrentDictionary<Type, ISessionVariables> dictionary
            = new ConcurrentDictionary<Type, ISessionVariables>();
    
        internal ISessionVariable Get<T>() where T : ISessionVariable, new()
        {
            return dictionary.GetOrAdd(typeof(T), _ => new T());
        }
    }
