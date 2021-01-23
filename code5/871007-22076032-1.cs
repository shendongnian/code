    public class MyClassProcessor
        public static int ProcessObject(MyClass myClass) {
            return myClass.MyInt ++;
        }
    }
    
    public class Runner {
        public void Run() {
            var classToPass = new MyClass();
            
            FuncExecutor.ExecuteAction<MyClass>(MyClassProcessor.ProcessObject, classToPass);
        }
    }
    
    public class FuncExecutor {
        public static void ExecuteAction<T>(Func<T, int> process, T obj) {
            int result = process(obj);
        }
    }
