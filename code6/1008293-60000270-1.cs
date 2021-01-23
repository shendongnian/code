    class Program
    {
        static void Main(string[] args)
        {
            // instead of class initialization we would have these registrations, e.g.:
            // diContainer.Resolve<IMyApplication>().With<MyDIApplication>();
            // diContainer.Resolve<ITerminator>().With<Terminator>();
            IMyApplication app = new MyDIApplication(new Terminator());
            app.Run();
        }
        public interface IMyApplication { void Run(); }
        public class MyDIApplication : IMyApplication
        {
            private readonly ITerminator terminator;
            public MyDIApplication(ITerminator terminatorDependency)
            {
                this.terminator = terminatorDependency;
            }
            public void Run()
            {
                terminator.Terminate(); // instance method call
                Terminator.Terminate(); // static method call
            }
        }
        public interface ITerminator { void Terminate(); }
        public class Terminator : ITerminator
        {
            public static void Terminate() => Console.WriteLine("Static method call.");
            void ITerminator.Terminate() => Console.WriteLine("Non-static method call.");
        }
    }
