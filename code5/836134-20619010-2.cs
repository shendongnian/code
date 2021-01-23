    public class MyClass1
    {
        private UnityContainer _container;
        public void Main()
        {
            this.RegisterContainer();
            // Since SomeClass was registered, when you resolve MyClass2, it will
            // magically resolve an instance of SomeClass that the MyClass2 
            // constructor needs.
            var myObject2 = this._container.Resolve<MyClass2>;
            myObject2.MethodWithDependency();
        }
        private void RegisterContainer()
        {
            // Here, initialize your Container then register your singletons.
            this._container = new UnityContainer();
            // Do not use container.RegisterType<>()....
            // Use RegisterInstance which, by default, implements a singleton behavior.
            this._container.RegisterInstance<SomeClass>();
            this._container.RegisterInstance<MyClass2>();
        }
    }
    public class MyClass2
    {
        private SomeClass _someClass;
        // You are injecting the SomeClass dependency into your MyClass2 class.
        // Hence the name — Dependency Injection.
        public MyClass2(SomeClass someClass)
        {
            this._someClass = someClass;
        }
        
        public void MethodWithDependency()
        {
            // use your _someClass object.
            this._someClass.DoSomething();
        }
    }
