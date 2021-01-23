    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace PicInvoke
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                this.InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                Stopwatch sw;
                // Sequential processing.
                sw = Stopwatch.StartNew();
                this.DoWorkAndBlockSequential();
                sw.Stop();
                MessageBox.Show(string.Format("Sequential work complete. Time taken: {0:0.000}s.", (double)sw.ElapsedMilliseconds / 1000.0));
                // Parallel processing.
                sw = Stopwatch.StartNew();
                this.DoWorkAndBlockParallel();
                sw.Stop();
                MessageBox.Show(string.Format("Parallel work complete. Time taken: {0:0.000}s.", (double)sw.ElapsedMilliseconds / 1000.0));
            }
            private void DoWorkAndBlockSequential()
            {
                for (int i = 0; i < 5; i++)
                {
                    var task = this.DoWorkAsync();
                    // Block the UI thread until the task has completed.
                    var action = task.Result;
                    // Invoke the delegate.
                    action();
                }
            }
            private void DoWorkAndBlockParallel()
            {
                var tasks = Enumerable
                    .Range(0, 5)
                    .Select(_ => this.DoWorkAsync())
                    .ToArray();
                // Block UI thread until all tasks complete.
                Task.WaitAll(tasks);
                foreach (var task in tasks)
                {
                    var action = task.Result;
                    // Invoke the delegate.
                    action();
                }
            }
            private Task<Action> DoWorkAsync()
            {
                // Note: this CANNOT synchronously post messages
                // to the UI thread as that will cause a deadlock.
                return Task
                    // Simulate async work.
                    .Delay(TimeSpan.FromSeconds(1))
                    // Tell the UI thread what needs to be done via Task.Result.
                    // We are not performing the work here - merely telling the
                    // caller what needs to be done.
                    .ContinueWith(
                        _ => new Action(this.Method),
                        TaskContinuationOptions.ExecuteSynchronously);
            }
            private void Method()
            {
                pic.BackColor = Color.Blue;
            }
        }
    }
