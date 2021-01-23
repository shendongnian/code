    using System;
    using System.Reflection;
    using System.Threading;
    namespace App
    {
        class Program
        {
            public event EventHandler<ThreadExceptionEventArgs> E;
            static void Main ()
            {
                new Program().Run();
            }
            private void Run ()
            {
                EventInfo e = typeof(Program).GetEvent("E");
                EventHandler untypedHandler = OnE;
                Delegate typedHandler = Delegate.CreateDelegate(e.EventHandlerType,
                    untypedHandler.Target, untypedHandler.Method);
                e.AddEventHandler(this, typedHandler);
                E(this, new ThreadExceptionEventArgs(new Exception("Hello world!")));
            }
            private void OnE (object sender, EventArgs args)
            {
                Console.WriteLine(((ThreadExceptionEventArgs)args).Exception.Message);
            }
        }
    }
