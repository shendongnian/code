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
                    await RequestNotificationAsync(useFakeSyncContext: false);
                    Debug.WriteLine(String.Empty);
    
                    await RequestNotificationAsync(useFakeSyncContext: true);
                    Debug.WriteLine(String.Empty);
    
                    // test on a pool thread
                    await Task.Run(() => RequestNotificationAsync(useFakeSyncContext: false));
                    Debug.WriteLine(String.Empty);
    
                    await Task.Run(() => RequestNotificationAsync(useFakeSyncContext: true));
                    Debug.WriteLine(String.Empty);
                };
            }
    
            async Task RegisterNotification(TaskCompletionSource<object> tcs, bool useFakeSyncContext)
            {
                await Task.Delay(500);
    
                Debug.WriteLine("A.before");
    
                if (useFakeSyncContext)
                {
                    using (new FakeSynchronizationContext())
                        tcs.SetResult(null);
                }
                else
                {
                    tcs.SetResult(null);
                }
    
                Debug.WriteLine("A.after");
            }
    
            async Task RequestNotificationAsync(bool useFakeSyncContext)
            {
                var tcs = new TaskCompletionSource<object>();
                var task = this.RegisterNotification(tcs, useFakeSyncContext);
    
                Debug.WriteLine("B.before");
    
                var data = await tcs.Task;
    
                // do not yeild
                Thread.Sleep(500); 
                Debug.WriteLine("B.after");
    
                // yeild
                await Task.Delay(500); 
            }
        }
    
    
        // FakeSynchronizationContext
        class FakeSynchronizationContext : SynchronizationContext, IDisposable
        {
            SynchronizationContext _saved;
            bool _disposed;
    
            public FakeSynchronizationContext()
            {
                _saved = SynchronizationContext.Current;
                SynchronizationContext.SetSynchronizationContext(this);
            }
    
            public override SynchronizationContext CreateCopy()
            {
                return this;
            }
    
            public override void OperationStarted()
            {
                throw new NotImplementedException();
            }
    
            public override void OperationCompleted()
            {
                throw new NotImplementedException();
            }
    
            public override void Post(SendOrPostCallback d, object state)
            {
                throw new NotImplementedException();
            }
    
            public override void Send(SendOrPostCallback d, object state)
            {
                throw new NotImplementedException();
            }
    
            public void Dispose()
            {
                if (!_disposed)
                {
                    _disposed = true;
                    SynchronizationContext.SetSynchronizationContext(_saved);
                    _saved = null;
                }
            }
        }
    }
