    using System;
    using System.Diagnostics;
    using System.Threading;
    
    namespace TestApp
    {
        static class Ext
        {
            [System.Diagnostics.DebuggerNonUserCode()]
            public static bool TryThrowIfCancellationRequested(
                this CancellationToken token)
            {
                try
                {
                    // debugger won't stop here, because of DebuggerNonUserCode attr
                    token.ThrowIfCancellationRequested();
                    return true;
                }
                catch (OperationCanceledException)
                {
                    return false;
                }
            }
        }
    
        public class Program
        {
            static bool SomeMethod(CancellationToken token)
            {
                System.Threading.Thread.Sleep(1000);
                return token.TryThrowIfCancellationRequested();
            }
    
            public static void Main()
            {
                var cts = new CancellationTokenSource(1000);
    
                for (var i = 0; i < 10; i++)
                {
                    if (!SomeMethod(cts.Token))
                        break;
                }
            }
        }
    }
