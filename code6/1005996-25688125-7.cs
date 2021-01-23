    public class SomeClass {
        public readonly IViewModelFactory _factory;
        public SomeClass(IViewModelFactory factory) {
            _factory = factory;
            var secondViewModel = _factory.Create<SecondViewModel>();
        }
    }
