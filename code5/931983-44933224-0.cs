    public static class ContainerBuilderExtensions
    {
        private static readonly IDictionary<Type, string> _implementationNames = new ConcurrentDictionary<Type, string>();
        public static void RegisterDecorated<T, TImplements>(this ContainerBuilder builder) where T : TImplements
        {
            builder.RegisterType<T>()
                .As<TImplements>()
                .Named<TImplements>(GetNameOf<TImplements>());
        }
        public static void RegisterDecorator<T, TImplements>(this ContainerBuilder builder) where T : TImplements
        {
            var nameOfServiceToDecorate = GetOutermostNameOf<TImplements>();
            builder.RegisterType<T>();
            builder.Register(c =>
            {
                var impl = c.ResolveNamed<TImplements>(nameOfServiceToDecorate);
                impl = c.Resolve<T>(TypedParameter.From(impl));
                return impl;
            })
                .As<TImplements>()
                .Named<TImplements>(GetNameOf<TImplements>());
        }
        private static string GetNameOf<T>()
        {
            var type = typeof(T);
            var name = type.FullName + Guid.NewGuid();
            _implementationNames[type] = name;
            return name;
        }
        private static string GetOutermostNameOf<T>()
        {
            var type = typeof(T);
            if (!_implementationNames.ContainsKey(type))
            {
                throw new Exception("Cannot call RegisterDecorator for an implementation that is not decorated. Ensure that you have called RegisterDecorated for this type before calling RegisterDecorator.");
            }
            return _implementationNames[typeof(T)];
        }
    }
