    public interface IMyInterface1 : IDisposable
    {
        void DoSomething();
    }
    public interface IMyInterface2 : IDisposable
    {
        void DoSomethingElse();
    }
    public class MyClass : IMyInterface1, IMyInterface2
    {
        public void DoSomething() { Console.WriteLine("I'm doing something..."); }
        public void DoSomethingElse() { Console.WriteLine("I'm doing something else..."); }
        public void Dispose() { Console.WriteLine("Bye bye!"); }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            using (IMyInterface1 myInterface = new MyClass())
            {
                myInterface.DoSomething();
            }
        }
    }
