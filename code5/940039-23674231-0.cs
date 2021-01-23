    public class MyUnMoqableClass {
        public string GetValue() {
            return "Hello World";
        }
    }
    public interface IMyUnMoqableClassProxy {
        string GetValue();
    }
    public class UnMoqableClassProxy : IMyUnMoqableClassProxy {
        private readonly MyUnMoqableClass _myUnMoqableClass;
		
        public UnMoqableClassProxy(MyUnMoqableClass myUnMoqableClass) {
            _myUnMoqableClass = myUnMoqableClass;
        }
        public string GetValue() {
            return _myUnMoqableClass.GetValue();
        }
    }
