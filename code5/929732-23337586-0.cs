    builder.RegisterType<MyClass>().As<IMyClass>();
    
    public SomeClass
    {
        public void SomeMethod()
        {
             var factory = container.Resolve<Func<string, IMyClass>>();
             var instance = factory(this.GetType().Namespace);
        }
    }
