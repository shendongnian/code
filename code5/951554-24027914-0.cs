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
                public async Task ParseDataAsync() 
                { 
                    // simulate download and parse
                    int delay = new Random(Environment.TickCount).Next(100, 1000);
                    await Task.Delay(delay);
                    Console.WriteLine("Processed: #{0}, delay: {1}", this.Url, delay);
                }
            }
    
            object _lock = new Object();
            HashSet<Task> _pending = new HashSet<Task>(); // sites in progress
            Queue<Site> _available = new System.Collections.Generic.Queue<Site>(); // sites to process
    
            async void ProcessSiteAsync(Site site, CancellationToken token)
            {
                Site nextSite = site;
    
                while (true)
                {
                    if (token.IsCancellationRequested)
                        break;
    
                    var task = nextSite.ParseDataAsync();
                    lock (_lock) _pending.Add(task);
                    try
                    {
                        await task;
                        lock (_lock)
                        {
                            _pending.Remove(task);
                            _available.Enqueue(nextSite);
                        }
                    }
                    catch
                    {
                        // a task error?
                        if (!task.IsCanceled && !task.IsFaulted)
                            throw; // non-task error, re-throw on the current syncrhonization context
    
                        // leave the task in the pending list and exit
                        // ProcessAllSites will pick it up
                    }
    
                    // get next available site
                    lock (_lock)
                    {
                        if (!_available.Any())
                            break; // no more sites to process
                        nextSite = _available.Dequeue();
                    }
                }
            }
    
            public async Task ProcessAllSites(IEnumerable<Site> sites, CancellationToken token)
            {
                // start all sites
                foreach (var site in sites)
                    ProcessSiteAsync(site, token);
    
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
                lock (_lock) tasks = _pending.ToArray();
                await Task.WhenAll(tasks);
            }
    
            // testing
            static void Main(string[] args)
            {
                var cts = new CancellationTokenSource(10000); // cancel processing in 10s
                var sites = Enumerable.Range(0, 10).Select(i => new Site { Url = i.ToString() });
                try
                {
                    new Program().ProcessAllSites(sites, cts.Token).Wait();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }
    }
