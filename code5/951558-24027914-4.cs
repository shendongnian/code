    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace AsyncLoop
    {
        class Program
        {
            public class Site
            {
                public string Url { get; set; }
                public async Task ParseDataAsync(CancellationToken token)
                {
                    // simulate download and parse
                    int delay = new Random(Environment.TickCount).Next(100, 1000);
                    await Task.Delay(delay, token);
                    Console.WriteLine("Processed: #{0}, delay: {1}", this.Url, delay);
                }
            }
    
            object _lock = new Object();
            HashSet<Task> _pending = new HashSet<Task>(); // sites in progress
            SemaphoreSlim _semaphore;
    
            async void QueueSiteAsync(Site site, CancellationToken token)
            {
                Func<Task> processSiteAsync = async () =>
                {
                    await _semaphore.WaitAsync(token).ConfigureAwait(false);
                    try 
                    {	        
                        await site.ParseDataAsync(token);
                        QueueSiteAsync(site, token);
                    }
                    finally
                    {
                        _semaphore.Release();
                    }
                };
    
                var task = processSiteAsync();
                lock (_lock)
                    _pending.Add(task);
                try
                {
                    await task;
                    lock (_lock)
                        _pending.Remove(task);
                }
                catch
                {
                    if (!task.IsCanceled && !task.IsFaulted)
                        throw; // non-task error, re-throw
    
                    // leave the faulted task in the pending list and exit
                    // ProcessAllSites will pick it up
                }
            }
    
            public async Task ProcessAllSites(
                Site[] sites, int maxParallel, CancellationToken token)
            {
                _semaphore = new SemaphoreSlim(Math.Min(sites.Length, maxParallel));
    
                // start all sites
                foreach (var site in sites)
                    QueueSiteAsync(site, token);
    
                // wait for cancellation
                try
                {
                    await Task.Delay(Timeout.Infinite, token);
                }
                catch (OperationCanceledException)
                {
                }
    
                // wait for pending tasks
                Task[] tasks;
                lock (_lock)
                    tasks = _pending.ToArray();
                await Task.WhenAll(tasks);
            }
    
            // testing
            static void Main(string[] args)
            {
                // cancel processing in 10s
                var cts = new CancellationTokenSource(millisecondsDelay: 10000); 
                var sites = Enumerable.Range(0, count: 10).Select(i => 
                    new Site { Url = i.ToString() });
                try
                {
                    new Program().ProcessAllSites(
                        sites.ToArray(), 
                        maxParallel: 5, 
                        token: cts.Token).Wait();
                }
                catch (AggregateException ex)
                {
                    foreach (var innerEx in ex.InnerExceptions)
                        Console.WriteLine(innerEx.Message);
                }
            }
        }
    }
