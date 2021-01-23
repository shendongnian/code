    using System.Threading;
    class MyClass
    {
        static void Main() { /* Won't run... the static constructor deadlocks */  }
        static MyClass()
        {
            Thread thread = new Thread(arg => { });
            thread.Start();
            thread.Join();
        }
    }
