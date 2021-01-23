    using System.ComponentModel;
    using System.Diagnostics;
    using System.Management.Automation;
    using System.Threading;
    using System.Windows.Forms;
    
    namespace CmdletExp
    {
    
        [Cmdlet("Invoke", "LongRunning")]
        public class InvokeLongRunningCommand : PSCmdlet
        {
            private readonly BackgroundWorker _backgroundWorker;
            private readonly AutoResetEvent _autoResetEvent;
    
            public InvokeLongRunningCommand()
            {
                SynchronizationContext.SetSynchronizationContext(new WindowsFormsSynchronizationContext());
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.WorkerReportsProgress = true;
                _backgroundWorker.DoWork += _backgroundWorker_DoWork;
                _backgroundWorker.ProgressChanged += _backgroundWorker_ProgressChanged;         
                _autoResetEvent = new AutoResetEvent(false);
            }
    
            protected override void EndProcessing()
            {
                Debug.WriteLine("EndProcessing ThreadId: " +  Thread.CurrentThread.ManagedThreadId);
                _backgroundWorker.RunWorkerAsync();
                do
                {
                    Application.DoEvents();
                } while (!_autoResetEvent.WaitOne(250));
                Application.DoEvents();
                base.EndProcessing();
            }
    
            void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                Debug.WriteLine("DoWork ThreadId: " + Thread.CurrentThread.ManagedThreadId);
                for (int i = 0; i < 20; i++)
                {
                    _backgroundWorker.ReportProgress(i * 5);
                    Thread.Sleep(1000);
                }
                _autoResetEvent.Set();
            }
    
            void _backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                Debug.WriteLine("ProgressChanged ThreadId: " + Thread.CurrentThread.ManagedThreadId + " progress: " + e.ProgressPercentage);
                WriteVerbose("Progress is " + e.ProgressPercentage);
            }
        }
    }
