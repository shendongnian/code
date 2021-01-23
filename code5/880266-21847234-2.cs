    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_21842880
    {
        class Program
        {
            BlockingCollection<object> _commonQueue;
    
            // process an individual queue
            void ProcessQueue(int id, BlockingCollection<object> queue, CancellationToken token)
            {
                while (true)
                {
                    // observe cancellation
                    token.ThrowIfCancellationRequested();
                    // get a message, this blocks and waits
                    var message = queue.Take(token);
    
                    // process this message
                    // just place it to the common queue
                    var wrapperMessage = "queue " + id + ", message: " + message;
                    _commonQueue.Add(wrapperMessage);
                }
            }
    
            // process the common aggregated queue
            void ProcessCommonQeueue(CancellationToken token)
            {
                while (true)
                {
                    // observe cancellation
                    token.ThrowIfCancellationRequested();
                    // this blocks and waits
    
                    // get a message, this blocks and waits
                    var message = _commonQueue.Take(token);
    
                    // process this message
                    Console.WriteLine(message.ToString());
                }
            }
    
            // run the whole process
            async Task RunAsync(CancellationToken token)
            {
                var queues = new List<BlockingCollection<object>>();
                _commonQueue = new BlockingCollection<object>();
    
                // start individual queue processors
                var tasks = Enumerable.Range(0, 4).Select((i) =>
                {
                    var queue = new BlockingCollection<object>();
                    queues.Add(queue);
    
                    return Task.Factory.StartNew(
                        () => ProcessQeueue(i, queue, token), 
                        TaskCreationOptions.LongRunning);
                }).ToList();
    
                // start the common queue processor
                tasks.Add(Task.Factory.StartNew(
                    () => ProcessCommonQeueue(token),
                    TaskCreationOptions.LongRunning));
    
                // start the simulators
                tasks.AddRange(Enumerable.Range(0, 4).Select((i) => 
                    SimulateMessagesAsync(queues, token)));
    
                // wait for all started tasks to complete
                await Task.WhenAll(tasks);
            }
    
            // simulate a message source
            async Task SimulateMessagesAsync(List<BlockingCollection<object>> queues, CancellationToken token)
            {
                var random = new Random(Environment.TickCount);
                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    await Task.Delay(random.Next(100, 1000));
                    var queue = queues[random.Next(0, queues.Count)];
                    var message = Guid.NewGuid().ToString() + " " +  DateTime.Now.ToString();
                    queue.Add(message);
                }
            }
    
            // entry point
            static void Main(string[] args)
            {
                Console.WriteLine("Ctrl+C to stop...");
    
                var cts = new CancellationTokenSource();
                Console.CancelKeyPress += (s, e) =>
                {
                    // cancel upon Ctrl+C
                    e.Cancel = true;
                    cts.Cancel();
                };
    
                try
                {
                    new Program().RunAsync(cts.Token).Wait();
                }
                catch (Exception ex)
                {
                    if (ex is AggregateException)
                        ex = ex.InnerException;
                    Console.WriteLine(ex.Message);
                }
    
                Console.WriteLine("Press Enter to exit");
                Console.ReadLine();
            }
        }
    }
