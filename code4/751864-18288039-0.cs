    public class MyClass : IMyInterface1, IMyInterface2
    {
        public void DoSomething()     { Console.WriteLine("I'm doing something..."); }
        public void DoSomethingElse() { Console.WriteLine("I'm doing something else..."); }
        void Dispose()                { Console.WriteLine("Bye bye!"); }
    }
