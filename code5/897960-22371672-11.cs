    var container = new Container();
    var context = new RuntimeValueContext();
    container.RegisterSingle<RuntimeValueContext>(context);
    container.Register<IMyClassFactory, MyClassFactory>();
    container.RegisterDecorator(typeof(IMyClass), typeof(MyClassDecorator));
    container.Register<IMyClass, MyClass>();
    
    public class RuntimeValueContext {
        private ThreadLocal<IRuntimeValue> _runtime;
        public IRuntimeValue RuntimeValue {
            get { return _runtime.Value; }
            set { _runtime.Value = value; }
        }
    }
    
    public class MyClassFactory : IMyClassFactory {
        private readonly Container _container;
        private readonly RuntimeValueContext context;
        public MyClassFactory(Container container, RuntimeValueContext context) {
            _container = container;
            _context = context;
        }
    
        public IMyClass Create(IRuntimeValue runtimeValue) {
            var instance = _container.GetInstance<IMyClass>();
            _context.RuntimeValue = runtimeValue;
            return instance;
        }
    }
    
    public class MyClass : IMyClass {
        private readonly RuntimeValueContext _context;
        public MyClass(RuntimeValueContext context) {
            _context = context;
        }
        public IRuntimeValue RuntimeValue { get { return _context.Value; } }
    }
