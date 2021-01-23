    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace Console_21666797
    {
        partial class Program
        {
            // the actual download method
            // async Task<string> DownloadNextPageAsync(string url) { ... }
    
            // the actual process methods
            // void ProcessResults(string data) { ... }
    
            // download and process all pages
            async Task DownloadAndProcessAllAsync(
                string startUrl, int maxDownloads, int maxProcesses)
            {
                // max parallel downloads
                var downloadSemaphore = new SemaphoreSlim(maxDownloads);
                // max parallel processing tasks
                var processSemaphore = new SemaphoreSlim(maxProcesses);
    
                var tasks = new HashSet<Task>();
                var complete = false;
                var protect = new Object(); // protect tasks
    
                var page = 0;
    
                // do the page
                Func<string, Task> doPageAsync = async (url) =>
                {
                    bool downloadSemaphoreAcquired = true;
                    try
                    {
                        // download the page
                        var data = await DownloadNextPageAsync(
                            url).ConfigureAwait(false);
    
                        if (String.IsNullOrEmpty(data))
                        {
                            Volatile.Write(ref complete, true);
                        }
                        else
                        {
                            // enable the next download to happen
                            downloadSemaphore.Release();
                            downloadSemaphoreAcquired = false;
    
                            // process this download 
                            await processSemaphore.WaitAsync();
                            try
                            {
                                await Task.Run(() => ProcessResults(data));
                            }
                            finally
                            {
                                processSemaphore.Release();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Volatile.Write(ref complete, true);
                        throw;
                    }
                    finally
                    {
                        if (downloadSemaphoreAcquired)
                            downloadSemaphore.Release();
                    }
                };
    
                // do the page and save the task
                Func<string, Task> queuePageAsync = async (url) =>
                {
                    var task = doPageAsync(url);
    
                    lock (protect)
                        tasks.Add(task);
    
                    await task;
    
                    lock (protect)
                        tasks.Remove(task);
                }; 
    
                // process pages in a loop until complete is true 
                while (!Volatile.Read(ref complete))
                {
                    page++;
    
                    // acquire download semaphore synchrnously
                    await downloadSemaphore.WaitAsync().ConfigureAwait(false);
                  
                    // do the page 
                    var task = queuePageAsync(startUrl + "?page=" + page);
                }
    
                // await completion of the pending tasks
                Task[] pendingTasks;
                lock (protect)
                    pendingTasks = tasks.ToArray();
                await Task.WhenAll(pendingTasks);
            }
    
            static void Main(string[] args)
            {
                new Program().DownloadAndProcessAllAsync("http://google.com", 10, 5).Wait();
                Console.ReadLine();
            }
        }
    }
