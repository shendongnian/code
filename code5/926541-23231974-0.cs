    using System;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;
    
    class PortDataReceived
    {
        public static async Task ReadPort(SerialPort port, CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();
    
                await TaskExt.FromEvent<SerialDataReceivedEventHandler, SerialDataReceivedEventArgs>(
                    (complete, cancel, reject) => // get handler
                        (sender, args) => complete(args),
                    handler => // subscribe
                        port.DataReceived += handler,
                    handler => // unsubscribe
                        port.DataReceived -= handler,
                    (complete, cancel, reject) => // start the operation
                        { if (port.BytesToRead != 0) complete(null); },
                    token);
    
                Console.WriteLine("Received: " + port.ReadExisting());
            }
        }
    
        public static void Main()
        {
            SerialPort port = new SerialPort("COM1");
    
            port.BaudRate = 9600;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.Handshake = Handshake.None;
    
            port.Open();
    
            Console.WriteLine("Press Enter to stop...");
            Console.WriteLine();
    
            var cts = new CancellationTokenSource();
            var task = ReadPort(port, cts.Token);
            
            Console.ReadLine();
    
            cts.Cancel();
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
            }
    
            port.Close();
        }
    
        // FromEvent<>, based on http://stackoverflow.com/a/22798789/1768303
        public static class TaskExt
        {
            public static async Task<TEventArgs> FromEvent<TEventHandler, TEventArgs>(
                Func<Action<TEventArgs>, Action, Action<Exception>, TEventHandler> getHandler,
                Action<TEventHandler> subscribe,
                Action<TEventHandler> unsubscribe,
                Action<Action<TEventArgs>, Action, Action<Exception>> initiate,
                CancellationToken token) where TEventHandler : class
            {
                var tcs = new TaskCompletionSource<TEventArgs>();
    
                Action<TEventArgs> complete = (args) => tcs.TrySetResult(args);
                Action cancel = () => tcs.TrySetCanceled();
                Action<Exception> reject = (ex) => tcs.TrySetException(ex);
    
                TEventHandler handler = getHandler(complete, cancel, reject);
    
                subscribe(handler);
                try
                {
                    using (token.Register(() => tcs.TrySetCanceled()))
                    {
                        initiate(complete, cancel, reject);
                        return await tcs.Task;
                    }
                }
                finally
                {
                    unsubscribe(handler);
                }
            }
        }
    }
