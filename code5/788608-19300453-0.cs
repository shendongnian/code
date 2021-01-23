    public class Test
    {
        public void Method()
        {
            Console.WriteLine(this == null);
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            //Your code goes here
            object t = new Test();
            var methodInfo = t.GetType().GetMethod("Method");
            var a = (Action)Delegate.CreateDelegate(typeof(Action), null, methodInfo);
            a();
        }
    }
