    class Program
        {
            static void Main(string[] args)
            {
                Test<string> t1 = new Test<string>(action: MyMethod1);
                Test<string> t2 = new Test<string>(function: MyMethod2);
    
    
                Test<string> t = new Test<string>();
                t.MyMethod1(MyMethod1);
                t.MyMethod2(MyMethod2);
            }
            public static void MyMethod1(string value)
            {
                Console.WriteLine("my method1 {0}", value);
            }
            public static string MyMethod2(string value)
            {
                Console.WriteLine("my method2 {0}", value);
                return string.Empty;
            }
        }
        public class Test<T>
        {
            //constructors
            public Test() { }
            public Test(Action<T> action)
            {
    
                object args = "action";
                action.Invoke((T)args); // here you should invoke the method in order to execute it
            }
            public Test(Func<T, T> function)
            {
                object args = "function";
                function.Invoke((T)args);
            }
    
            //methods with same signature of constructor
            public void MyMethod1(Action<T> action)
            {
                object args = "Method 3";
                action.Invoke((T)args);
            }
            public void MyMethod2(Func<T, T> action)
            {
                object args = "Method 4";
                action.Invoke((T)args);
            }
        }
