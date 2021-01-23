    using System.Threading;
    
    namespace FinalizerOrder
    {
        using System;
        using System.Collections.Generic;
        using System.Diagnostics;
    
        class Engine
        {
            private Engine()
            {
                //ActivateEngine() is no longer called here.
            }
    
            private readonly static Engine _singleton = new Engine(); //Now that the constructor is empty we can initialize immediately.
            private readonly static object _syncLock = new object();
            private static volatile int _counter = 0;
    
            public static Engine Singleton
            {
                get { return _singleton; }
            }
    
            public void AddRefrence()
            {
                lock (_syncLock)
                {
                    _counter++;
                    if (_counter < 0)
                        throw new InvalidOperationException("ReleaseRefrence() was called more times than AddRefrence()");
    
                    if(_counter == 1)
                        Debug.WriteLine("ActivateEngine() ...");
                }
            }
    
            public void ReleaseRefrence()
            {
                lock (_syncLock)
                {
                    _counter--;
    
                    if (_counter < 0)
                        throw new InvalidOperationException("ReleaseRefrence() was called more times than AddRefrence()");
    
                    if (_counter == 0)
                    {
                        Debug.WriteLine("TerminateEngine() ...");
                    }
                }
            }
        }
    
        class Module : IDisposable
        {
            public Module()
            {
                Engine.Singleton.AddRefrence();
    
                _id = _counter++;
                Debug.WriteLine("CreateModule() ==> {0} ...", _id);
    
            }
    
            private readonly int _id;
            private static int _counter;
    
            ~Module()
            {
                Dispose(false);   
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            private bool _disposed = false;
    
            protected void Dispose(bool disposing)
            {
                if(_disposed)
                    return;
                _disposed = true;                
                if (disposing)
                {
                    //Nothing to do here, no IDisposeable objects.
                }
    
                Debug.WriteLine("DestroyModule({0}) ...", _id);
                Engine.Singleton.ReleaseRefrence();
            }
        }
    
        internal class Program
        {
            private static void Main()
            {
                Test();
                GC.Collect(3, GCCollectionMode.Forced);
                GC.WaitForPendingFinalizers();
                Test();
    
            }
    
            private static void Test()
            {
                var module1 = new Module();
                var module2 = new Module();
    
                GC.KeepAlive(module2);
                GC.KeepAlive(module1);
            }
        }
    }
