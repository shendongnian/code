    public sealed class UnityOptionFactory : IOptionFactory
    {
        private readonly IUnityContainer _container;
        private readonly Dictionary<Option, Type> _optionMapping;
        public UnityOptionFactory(IUnityContainer container)
        {            
            var makeDerivedTwo = typeof(DerivedClassTwo);
            _optionMapping = new Dictionary<Option, Type>
            {
                { Option.Option1, typeof(DerivedClassOne) },
                { Option.Option2, makeDerivedTwo },
                { Option.Option3, makeDerivedTwo }
            };
        }
        public MyBaseClass Create(Option option)
        {
            return _container.Resolve(_optionMapping[option]);
        }
    }
