    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinFroms_21790151
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
    
                this.Load += MainForm_Load;
            }
    
            void MainForm_Load(object senderLoad, EventArgs eLoad)
            {
                using (var apartment = new MessageLoopApartment())
                {
                    // create WebBrowser on a seprate thread with its own message loop
                    var webBrowser = apartment.Run(() => new WebBrowser(), CancellationToken.None).Result;
    
                    // navigate and wait for the result 
    
                    var bodyHtml = apartment.Invoke(() =>
                    {
                        WebBrowserDocumentCompletedEventHandler handler = null;
                        var pageLoadedTcs = new TaskCompletionSource<string>();
                        handler = (s, e) =>
                        {
                            try
                            {
                                webBrowser.DocumentCompleted -= handler;
                                pageLoadedTcs.SetResult(webBrowser.Document.Body.InnerHtml);
                            }
                            catch (Exception ex)
                            {
                                pageLoadedTcs.SetException(ex);
                            }
                        };
    
                        webBrowser.DocumentCompleted += handler;
                        webBrowser.Navigate("http://example.com");
    
                        // return Task<string>
                        return pageLoadedTcs.Task;
                    }).Result;
    
                    MessageBox.Show("body content:\n" + bodyHtml);
    
                    // execute some JavaScript
    
                    var documentHtml = apartment.Invoke(() =>
                    {
                        // at least one script element must be present for eval to work
                        var scriptElement = webBrowser.Document.CreateElement("script");
                        webBrowser.Document.Body.AppendChild(scriptElement);
    
                        // inject and run some script
                        var scriptResult = webBrowser.Document.InvokeScript("eval", new[] { 
                            "(function(){ return document.documentElement.outerHTML; })();" 
                        });
    
                        return scriptResult.ToString();
                    });
                    
                    MessageBox.Show("document content:\n" + documentHtml);
    
                    // dispose of webBrowser
                    apartment.Run(() => webBrowser.Dispose(), CancellationToken.None).Wait();
                    webBrowser = null;
                }
            }
    
            // MessageLoopApartment
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
    
                public Task Run(Action action, CancellationToken token)
                {
                    return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
                }
    
                public Task<TResult> Run<TResult>(Func<TResult> action, CancellationToken token)
                {
                    return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler);
                }
    
                public Task Run(Func<Task> action, CancellationToken token)
                {
                    return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
                }
    
                public Task<TResult> Run<TResult>(Func<Task<TResult>> action, CancellationToken token)
                {
                    return Task.Factory.StartNew(action, token, TaskCreationOptions.None, _taskScheduler).Unwrap();
                }
            }
        }
    }
