    using System;
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
                var e = typeof(Program).GetEvent("E");
                var d1 = (EventHandler)OnE;
                var d2 = Delegate.CreateDelegate(e.EventHandlerType, d1.Target, d1.Method);
                e.AddEventHandler(this, d2);
                E(this, new ThreadExceptionEventArgs(new Exception()));
            }
            private void OnE (object sender, EventArgs args)
            {
                Console.WriteLine("Hello world!");
            }
        }
    }
