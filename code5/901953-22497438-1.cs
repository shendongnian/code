    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication_22487698
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
    
            IEnumerable<int> _data = Enumerable.Range(1, 100);
            Action _cancelWork;
    
            private void DoWorkItem(
                int[] data,
                int item,
                CancellationToken token,
                IProgress<int> progressReport,
                ParallelLoopState loopState)
            {
                // observe cancellation
                if (token.IsCancellationRequested)
                {
                    loopState.Stop();
                    return;
                }
    
                // simulate a work item
                Thread.Sleep(500);
    
                // update progress
                progressReport.Report(item);
            }
    
            private async void startButton_Click(object sender, EventArgs e)
            {
                // update the UI
                this.startButton.Enabled = false;
                this.stopButton.Enabled = true;
    
                try
                {
                    // prepare to handle cancellation
                    var cts = new CancellationTokenSource();
                    var token = cts.Token;
    
                    this._cancelWork = () =>
                    {
                        this.stopButton.Enabled = false;
                        cts.Cancel();
                    };
    
                    var data = _data.ToArray();
                    var total = data.Length;
    
                    // prepare the progress updates
                    this.progressBar.Value = 0;
                    this.progressBar.Minimum = 0;
                    this.progressBar.Maximum = total;
    
                    var progressReport = new Progress<int>((i) =>
                    {
                        this.progressBar.Increment(1);
                    });
    
                    // offload Parallel.For from the UI thread 
                    // as a long-running operation
                    await Task.Factory.StartNew(() =>
                    {
                        Parallel.For(0, total, (item, loopState) =>
                            DoWorkItem(data, item, token, progressReport, loopState));
                        // observe cancellation
                        token.ThrowIfCancellationRequested();
                    }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
    
                // update the UI
                this.startButton.Enabled = true;
                this.stopButton.Enabled = false;
                this._cancelWork = null;
            }
    
            private void stopButton_Click(object sender, EventArgs e)
            {
                if (this._cancelWork != null)
                    this._cancelWork();
            }
        }
    }
