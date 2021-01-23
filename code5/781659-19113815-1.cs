    namespace MyNamespace {
        public interface IMyInterface {
            void Method1();
        }
        public class MyClass : IMyInterface {
            public void Method1() {
                // Implementation
            }
        }
        public class CallerClass {
            public void MethodCaller() {
                IMyInterface instance = new MyClass();
                instance.Method1();
            }
        }
    }
