    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinForms_21845495
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
    
                this.Load += async (s, e) =>
                {
                    // test on WindowsFormsSynchronizationContext
                    await RequestNotificationAsync(notifyAsync: false);
                    Debug.WriteLine(String.Empty);
    
                    await RequestNotificationAsync(notifyAsync: true);
                    Debug.WriteLine(String.Empty);
    
                    // test on a pool thread
                    await Task.Run(() => RequestNotificationAsync(notifyAsync: false));
                    Debug.WriteLine(String.Empty);
    
                    await Task.Run(() => RequestNotificationAsync(notifyAsync: true));
                    Debug.WriteLine(String.Empty);
                };
            }
    
            async Task RegisterNotification(TaskCompletionSource<object> tcs, bool notifyAsync)
            {
                await Task.Delay(500);
    
                Debug.WriteLine("A.before");
    
                if (notifyAsync)
                {
                    tcs.SetResultAsync(null);
                }
                else
                {
                    tcs.SetResult(null);
                }
    
                Debug.WriteLine("A.after");
            }
    
            async Task RequestNotificationAsync(bool notifyAsync)
            {
                var tcs = new TaskCompletionSource<object>();
                var task = this.RegisterNotification(tcs, notifyAsync);
    
                Debug.WriteLine("B.before");
    
                var data = await tcs.Task;
    
                // do not yeild
                Thread.Sleep(500); 
                Debug.WriteLine("B.after");
    
                // yeild
                await Task.Delay(500); 
            }
        }
    
        public static class TaskExt
        {
            static public void SetResultAsync<T>(this TaskCompletionSource<T> tcs, T result)
            {
                FakeSynchronizationContext.Execute(() => tcs.SetResult(result));
            }
    
            // FakeSynchronizationContext
            class FakeSynchronizationContext : SynchronizationContext
            {
                private static readonly ThreadLocal<FakeSynchronizationContext> s_context =
                    new ThreadLocal<FakeSynchronizationContext>(() => new FakeSynchronizationContext());
    
                private FakeSynchronizationContext() { }
    
                public static FakeSynchronizationContext Instance { get { return s_context.Value; } }
    
                public static void Execute(Action action)
                {
                    var savedContext = SynchronizationContext.Current;
                    SynchronizationContext.SetSynchronizationContext(FakeSynchronizationContext.Instance);
                    try
                    {
                        action();
                    }
                    finally
                    {
                        SynchronizationContext.SetSynchronizationContext(savedContext);
                    }
                }
    
                // SynchronizationContext methods
    
                public override SynchronizationContext CreateCopy()
                {
                    return this;
                }
    
                public override void OperationStarted()
                {
                    throw new NotImplementedException("OperationStarted");
                }
    
                public override void OperationCompleted()
                {
                    throw new NotImplementedException("OperationCompleted");
                }
    
                public override void Post(SendOrPostCallback d, object state)
                {
                    throw new NotImplementedException("Post");
                }
    
                public override void Send(SendOrPostCallback d, object state)
                {
                    throw new NotImplementedException("Send");
                }
            }
        }
    }
