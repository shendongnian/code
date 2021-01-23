    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace AsyncWebBrowserScrapper
    {
        class Program
        {
            // by Noseratio - http://stackoverflow.com/a/23819021/1768303
    
            // test: web-scrap a list of URLs
            static async Task ScrapSitesAsync(string[] urls, CancellationToken token)
            {
                using (var pool = new WebBrowserPool(maxParallel: 2, token: token))
                {
                    // cancel each site in 30s or when the main token is signalled
                    var timeout = (int)TimeSpan.FromSeconds(30).TotalMilliseconds;
    
                    var results = urls.ToDictionary(
                        url => url, url => pool.ScrapSiteAsync(url, timeout));
    
                    await Task.WhenAll(results.Values);
    
                    foreach (var url in results.Keys)
                    {
                        Console.WriteLine("URL:\n" + url);
    
                        string html = results[url].Result;
    
                        Console.WriteLine("HTML:\n" + html);
                    }
                }
            }
    
            // entry point
            static void Main(string[] args)
            {
                try
                {
                    WebBrowserExt.SetFeatureBrowserEmulation(); // enable HTML5
    
                    var cts = new CancellationTokenSource((int)TimeSpan.FromMinutes(3).TotalMilliseconds);
    
                    var task = ScrapSitesAsync(
                        new[] { "http://example.com", "http://example.org", "http://example.net", "http://www.bing.com", "http://www.google.com" },
                        cts.Token);
    
                    task.Wait();
    
                    Console.WriteLine("Press Enter to exit...");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    while (ex is AggregateException && ex.InnerException != null)
                        ex = ex.InnerException;
                    Console.WriteLine(ex.Message);
                    Environment.Exit(-1);
                }
            }
        }
    
        /// <summary>
        /// WebBrowserPool the pool of WebBrowser objects sharing the same message loop
        /// </summary>
        public class WebBrowserPool : IDisposable
        {
            MessageLoopApartment _apartment; // a WinFroms STA thread with message loop
            readonly SemaphoreSlim _semaphore; // regulate available browsers
            readonly Queue<WebBrowser> _browsers; // the pool of available browsers
            readonly HashSet<Task> _pendingTasks; // keep track of pending tasks for proper cancellation
            readonly CancellationTokenSource _cts; // global cancellation (for Dispose)
    
            public WebBrowserPool(int maxParallel, CancellationToken token)
            {
                if (maxParallel < 1)
                    throw new ArgumentException("maxParallel");
    
                _cts = CancellationTokenSource.CreateLinkedTokenSource(token);
                _apartment = new MessageLoopApartment();
                _semaphore = new SemaphoreSlim(maxParallel);
                _browsers = new Queue<WebBrowser>();
                _pendingTasks = new HashSet<Task>();
    
                // init the pool of WebBrowser objects
                _apartment.Invoke(() =>
                {
                    while (--maxParallel >= 0)
                        _browsers.Enqueue(new WebBrowser());
                });
            }
    
            // Navigate to a site and get a snapshot of its DOM HTML
            public async Task<string> ScrapSiteAsync(string url, int timeout, CancellationToken token = default(CancellationToken))
            {
                var navigationCts = CancellationTokenSource.CreateLinkedTokenSource(token, _cts.Token);
                var combinedToken = navigationCts.Token;
    
                // we have a limited number of WebBrowser objects available, so await the semaphore
                await _semaphore.WaitAsync(combinedToken);
                try
                {
                    if (timeout != Timeout.Infinite)
                        navigationCts.CancelAfter(timeout);
    
                    // run the main logic on the STA thread
                    return await _apartment.Run(async () =>
                    {
                        // acquire the 1st available WebBrowser from the pool
                        var webBrowser = _browsers.Dequeue();
                        try
                        {
                            var task = webBrowser.NavigateAsync(url, combinedToken);
                            _pendingTasks.Add(task); // register the pending task
                            try
                            {
                                return await task;
                            }
                            finally
                            {
                                // unregister the completed task
                                _pendingTasks.Remove(task);
                            }
                        }
                        finally
                        {
                            // return the WebBrowser to the pool
                            _browsers.Enqueue(webBrowser);
                        }
                    }, combinedToken);
                }
                finally
                {
                    _semaphore.Release();
                }
            }
    
            // Dispose of WebBrowserPool
            public void Dispose()
            {
                if (_apartment == null)
                    throw new ObjectDisposedException(this.GetType().Name);
    
                // cancel and wait for all pending tasks
                _cts.Cancel();
                var task = _apartment.Run(() => Task.WhenAll(_pendingTasks.ToArray()));
                try
                {
                    task.Wait();
                }
                catch
                {
                    if (!task.IsCanceled)
                        throw;
                }
    
                // dispose of WebBrowser objects
                _apartment.Run(() =>
                {
                    while (_browsers.Any())
                        _browsers.Dequeue().Dispose();
                });
    
                _apartment.Dispose();
                _apartment = null;
            }
        }
    
        /// <summary>
        /// WebBrowserExt - WebBrowser extensions
        /// by Noseratio - http://stackoverflow.com/a/22262976/1768303
        /// </summary>
        public static class WebBrowserExt
        {
            const int POLL_DELAY = 500;
    
            // navigate and download 
            public static async Task<string> NavigateAsync(this WebBrowser webBrowser, string url, CancellationToken token)
            {
                // navigate and await DocumentCompleted
                var tcs = new TaskCompletionSource<bool>();
                WebBrowserDocumentCompletedEventHandler handler = (s, arg) =>
                    tcs.TrySetResult(true);
    
                using (token.Register(
                    () => { webBrowser.Stop(); tcs.TrySetCanceled(); },
                    useSynchronizationContext: true))
                {
                    webBrowser.DocumentCompleted += handler;
                    try
                    {
                        webBrowser.Navigate(url);
                        await tcs.Task; // wait for DocumentCompleted
                    }
                    finally
                    {
                        webBrowser.DocumentCompleted -= handler;
                    }
                }
    
                // get the root element
                var documentElement = webBrowser.Document.GetElementsByTagName("html")[0];
    
                // poll the current HTML for changes asynchronosly
                var html = documentElement.OuterHtml;
                while (true)
                {
                    // wait asynchronously, this will throw if cancellation requested
                    await Task.Delay(POLL_DELAY, token);
    
                    // continue polling if the WebBrowser is still busy
                    if (webBrowser.IsBusy)
                        continue;
    
                    var htmlNow = documentElement.OuterHtml;
                    if (html == htmlNow)
                        break; // no changes detected, end the poll loop
    
                    html = htmlNow;
                }
    
                // consider the page fully rendered 
                token.ThrowIfCancellationRequested();
                return html;
            }
    
            // enable HTML5 (assuming we're running IE10+)
            // more info: http://stackoverflow.com/a/18333982/1768303
            public static void SetFeatureBrowserEmulation()
            {
                if (System.ComponentModel.LicenseManager.UsageMode != System.ComponentModel.LicenseUsageMode.Runtime)
                    return;
                var appName = System.IO.Path.GetFileName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
                    appName, 10000, RegistryValueKind.DWord);
            }
        }
    
        /// <summary>
        /// MessageLoopApartment
        /// STA thread with message pump for serial execution of tasks
        /// by Noseratio - http://stackoverflow.com/a/22262976/1768303
        /// </summary>
        public class MessageLoopApartment : IDisposable
        {
            Thread _thread; // the STA thread
    
            TaskScheduler _taskScheduler; // the STA thread's task scheduler
    
            public TaskScheduler TaskScheduler { get { return _taskScheduler; } }
    
            /// <summary>MessageLoopApartment constructor</summary>
            public MessageLoopApartment()
            {
                var tcs = new TaskCompletionSource<TaskScheduler>();
    
                // start an STA thread and gets a task scheduler
                _thread = new Thread(startArg =>
                {
                    EventHandler idleHandler = null;
    
                    idleHandler = (s, e) =>
                    {
                        // handle Application.Idle just once
                        Application.Idle -= idleHandler;
                        // return the task scheduler
                        tcs.SetResult(TaskScheduler.FromCurrentSynchronizationContext());
                    };
    
                    // handle Application.Idle just once
                    // to make sure we're inside the message loop
                    // and SynchronizationContext has been correctly installed
                    Application.Idle += idleHandler;
                    Application.Run();
                });
    
                _thread.SetApartmentState(ApartmentState.STA);
                _thread.IsBackground = true;
                _thread.Start();
                _taskScheduler = tcs.Task.Result;
            }
    
            /// <summary>shutdown the STA thread</summary>
            public void Dispose()
            {
                if (_taskScheduler != null)
                {
                    var taskScheduler = _taskScheduler;
                    _taskScheduler = null;
    
                    // execute Application.ExitThread() on the STA thread
                    Task.Factory.StartNew(
                        () => Application.ExitThread(),
                        CancellationToken.None,
                        TaskCreationOptions.None,
                        taskScheduler).Wait();
    
                    _thread.Join();
                    _thread = null;
                }
            }
    
            /// <summary>Task.Factory.StartNew wrappers</summary>
            public void Invoke(Action action)
            {
                Task.Factory.StartNew(action,
                    CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Wait();
            }
    
            public TResult Invoke<TResult>(Func<TResult> action)
            {
                return Task.Factory.StartNew(action,
                    CancellationToken.None, TaskCreationOptions.None, _taskScheduler).Result;
            }
    
            public Task Run(Action action, CancellationToken token = default(CancellationToken))
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
            }
    
            public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token = default(CancellationToken))
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
            }
    
            public Task Run(Func<Task> action, CancellationToken token = default(CancellationToken))
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
            }
    
            public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token = default(CancellationToken))
            {
                return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
            }
        }
    }
