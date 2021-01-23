    public class SomeViewModel : Screen
    {
        private readonly IFoo foo;
        public SomeViewModel(IFoo foo)
        {
           // Can use foo later, e.g. in OnActivate for your screen
           this.foo = foo;            
        }
    }
