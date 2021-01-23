    public class ArgScopeAccessor : IScopeAccessor
    {
        static readonly ConcurrentDictionary<string, ILifetimeScope> collection = new ConcurrentDictionary<string, ILifetimeScope>();
        public void Dispose()
        {
            foreach (var scope in collection)
                scope.Value.Dispose();
            collection.Clear();
        }
        public ILifetimeScope GetScope(CreationContext context)
        {
            string name = (string)context.AdditionalArguments["name"];
            return collection.GetOrAdd(name, n => new DefaultLifetimeScope());
        }
    }
