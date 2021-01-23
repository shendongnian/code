    public class CalculatorBootstrapper : BootstrapperBase {
        
        private Func<Type, string, object> _previousGet;     
        public override void Configure() {
            _previousGet = IoC.GetInstance; // store reference to whatever was stored previously
            IoC.GetInstance = this.GetInstance;
        }
        public override Object GetInstance(Type type, string key) {
            var result = null;
            if (_previousGet != null)
                result = _previousGet(type, key);
            if (result == null) {
                // Try to use the local container here
                
            }
            return result;
        }
    }
