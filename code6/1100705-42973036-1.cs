    public interface IGeneric<T>
    {
        void SomeMethod();
    }
    class IntImpl : IGeneric<int>
    {
        public void SomeMethod() { }
    }
    class StringImpl : IGeneric<string>
    {
        public void SomeMethod() { }
    }
    class GenericDecorator<T> : IGeneric<T>
    {
        IGeneric<T> target;
        public GenericDecorator(IGeneric<T> target)
        {
            this.target = target;
        }
        public void SomeMethod()
        {
            target.SomeMethod();
        }
    }
    static void Configure(ContainerBuilder builder)
    {
        builder.RegisterType<IntImpl>().Named<IGeneric<int>>("generic");
        builder.RegisterType<StringImpl>().Named<IGeneric<string>>("generic");
        builder.RegisterGenericDecorators(typeof(IGeneric<>), "generic")
            // applying decorator to IGeneric<string> only
            .Decorator(typeof(GenericDecorator<>), t => typeof(IGeneric<string>).IsAssignableFrom(t));
        }
