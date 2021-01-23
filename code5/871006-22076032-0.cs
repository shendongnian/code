    public interface IObjectProcessor<T> {
        public int ProcessObject(T instance);
    }
    
    public class MyClassProcessor : IObjectProcessor<MyClass> {
        public int ProcessObject(MyClass myClass) {
            return myClass.MyInt ++;
        }
    }
    
    public class Runner {
        public void Run() {
            var classToPass = new MyClass();
            var processor = new MyClassProcessor();
            
            FuncExecutor.ExecuteAction<MyClass>(processor, classToPass);
        }
    }
    
    public class FuncExecutor {
        public static void ExecuteAction<T>(IObjectProcessor<T> processor, T obj) {
            int result = processor.ProcessObject(obj);
        }
    }
