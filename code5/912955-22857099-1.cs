    using System;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication
    {
        class Program
        {
            public class TelegramEventArg: EventArgs
            {
                public byte[] Data { get; set; }
            }
    
            public EventHandler<TelegramEventArg> TelegramEvent = delegate { };
    
            async Task<byte[]> ReadTelegramAsync(int size, CancellationToken token)
            {
                var tcs = new TaskCompletionSource<byte[]>();
                EventHandler<TelegramEventArg> handler = null;
                bool subscribed = false;
                
                handler = (s, e) => 
                {
                    if (e.Data.Length == size)
                    {
                        this.TelegramEvent -= handler;
                        subscribed = false;
                        tcs.TrySetResult(e.Data);
                    }
                };
    
                this.TelegramEvent += handler;
                try
                {
                    subscribed = true;
                    using (token.Register(() => tcs.TrySetCanceled()))
                    {
                        await tcs.Task.ConfigureAwait(false);
                        return tcs.Task.Result;
                    }
                }
                finally
                {
                    if (subscribed)
                        this.TelegramEvent -= handler;
                }
            }
    
            async Task ReadBusAsync(CancellationToken token)
            {
                while (true)
                {
                    // get data from the bus
                    var data = await Task.Factory.FromAsync(
                        (asyncCallback, asyncState) => 
                            readBus.BeginInvoke(asyncCallback, asyncState),
                        (asyncResult) => 
                            readBus.EndInvoke(asyncResult), 
                        state: null).ConfigureAwait(false);
    
                    token.ThrowIfCancellationRequested();
                    this.TelegramEvent(this, new TelegramEventArg { Data = data });
                }
            }
    
            // simulate the async bus driver with BeginXXX/EndXXX APM API
            static readonly Func<byte[]> readBus = () =>
            {
                var random = new Random(Environment.TickCount);
                Thread.Sleep(random.Next(1, 500));
                var data = new byte[random.Next(1, 5)];
                Console.WriteLine("A bus message of {0} bytes", data.Length);
                return data;
            };
    
            static void Main(string[] args)
            {
                try
                {
                    var program = new Program();
                    var cts = new CancellationTokenSource(Timeout.Infinite); // cancel in 10s
    
                    var task1 = program.ReadTelegramAsync(1, cts.Token);
                    var task2 = program.ReadTelegramAsync(2, cts.Token);
                    var task3 = program.ReadTelegramAsync(3, cts.Token);
    
                    var busTask = program.ReadBusAsync(cts.Token);
    
                    Task.WaitAll(task1, task2, task3);
                    Console.WriteLine("All telegrams received");
                    cts.Cancel(); // stop ReadBusAsync
                }
                catch (Exception ex)
                {
                    while (ex is AggregateException)
                        ex = ex.InnerException;
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
