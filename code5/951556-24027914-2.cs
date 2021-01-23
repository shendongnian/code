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
            Queue<Site> _available = new System.Collections.Generic.Queue<Site>(); // sites to process
    
            async Task ProcessSiteAsync(Site site, CancellationToken token)
            {
                Site nextSite = site;
    
                while (true)
                {
                    token.ThrowIfCancellationRequested();
    
                    await nextSite.ParseDataAsync(token);
    
                    // get next available site
                    lock (_lock)
                    {
                        _available.Enqueue(nextSite);
                        nextSite = _available.Dequeue();
                    }
                }
            }
    
            public async Task ProcessAllSites(IEnumerable<Site> sites, CancellationToken token)
            {
                // start all sites
                var tasks = sites.Select(site => ProcessSiteAsync(site, token)).ToArray();
    
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
