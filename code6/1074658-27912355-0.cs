    public class CountingInterfaceBindingGenerator : IBindingGenerator
    {
        private readonly IBindingGenerator innerBindingGenerator;
        public CountingInterfaceBindingGenerator()
        {
            this.innerBindingGenerator =
                new AllInterfacesBindingGenerator(new BindableTypeSelector(), new SingleConfigurationBindingCreator());
        }
        public int Count { get; private set; }
        public IEnumerable<IBindingWhenInNamedWithOrOnSyntax<object>> CreateBindings(Type type, IBindingRoot bindingRoot)
        {
            this.Count++;
            return this.innerBindingGenerator.CreateBindings(type, bindingRoot);
        }
    }
