    using System;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WinformsApp
    {
        public partial class MainForm : Form
        {
            CancellationTokenSource _cts;
            Task _task;
    
            // Form Load event
            void MainForm_Load(object sender, EventArgs e)
            {
                _cts = new CancellationTokenSource();
                _task = DoWorkAsync(_cts.Token);
            }
    
            // Form Closing event
            void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                ShowModalWaitMessage();
            }
    
            // Show a message and wait
            void ShowModalWaitMessage()
            {
                var dialog = new Form();
    
                dialog.Load += async (s, e) =>
                {
                    var startTick = Environment.TickCount;
    
                    _cts.Cancel();
                    try
                    {
                        await _task;
                    }
                    catch (Exception ex)
                    {
                        if (ex is AggregateException)
                            ex = ex.InnerException;
                        if (!(ex is OperationCanceledException))
                            throw;
                    }
    
                    // show the dialog for at least 2 secs
                    await Task.Delay(Math.Max(2000, Environment.TickCount - startTick));
                    dialog.Close();
                };
    
                dialog.ShowIcon = false; dialog.ShowInTaskbar = false;
                dialog.FormBorderStyle = FormBorderStyle.FixedToolWindow;
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.Width = 160; dialog.Height = 100;
    
                var label = new Label();
                label.Text = "Closing, please wait...";
                label.AutoSize = true;
                dialog.Controls.Add(label);
    
                dialog.ShowDialog();
            }
    
            // async work
            async Task DoWorkAsync(CancellationToken ct)
            {
                var i = 0;
                while (true)
                {
                    ct.ThrowIfCancellationRequested();
    
                    var item = i++;
                    await Task.Run(() =>
                    {
                        Debug.Print("Starting work item " + item);
                        // use Sleep as a mock for some atomic operation which cannot be cancelled
                        Thread.Sleep(1000);
                        Debug.Print("Finished work item " + item);
                    }, ct);
                }
            }
    
            public MainForm()
            {
                InitializeComponent();
                this.FormClosing += MainForm_FormClosing;
                this.Load += MainForm_Load;
            }
        }
    }
