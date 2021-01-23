    public class SomeClass : ISomeClass
    {
        private IServiceHelperFactory factory;
        
        public SomeClass(IServiceHelperFactory factory)
        {
            this.factory = factory;
        }
        
        public void ThisMethodCreatesTheServiceHelper()
        {
            var helper = this.factory.CreateServiceHelper("some service name");
        }
    }
