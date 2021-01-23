    // returns an enumeration of T where o : IEnumerable<T>
    public IEnumerable<Type> GetGenericIEnumerables(object o) {
        return o.GetType()
                .GetInterfaces()
                .Where(t => t.IsGenericType == true
                    && t.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                .Select(t => t.GetGenericArguments()[0]);
    }
