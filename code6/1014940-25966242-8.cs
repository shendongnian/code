    using System;
    using System.Threading;
    using System.Windows.Forms;
    namespace FormClosingExample
    {
        public partial class Form1 : Form
        {
            private volatile bool Scanning = true;
            private readonly ManualResetEvent LoopFinishedMre = new ManualResetEvent(false);
            private readonly SynchronizationContext UiContext;
            public Form1()
            {
                this.InitializeComponent();
                // Capture UI context.
                this.UiContext = SynchronizationContext.Current;
                // Spin up the worker thread.
                new Thread(this.Loop).Start();
            }
            private void Loop()
            {
                int i = 0;
                while (this.Scanning)
                {
                    // Some operation on unmanaged resource.
                    i++;
                    // Asynchronous UI-bound action (progress reporting).
                    // We can't use Send here because it will deadlock if
                    // the call to WaitOne sneaks in between the Scanning
                    // check and sync context dispatch.
                    this.UiContext.Post(_ =>
                    {
                        // Note that it is possible that this will
                        // execute *after* Scanning is set to false
                        // (read: when the form has already closed),
                        // in which case the control *might* have
                        // already been disposed.
                        if (this.Scanning)
                        {
                            this.Text = i.ToString();
                        }
                    }, null);
                    // Artifical delay.
                    Thread.Sleep(1000);
                }
                // Tell the FormClosing handler that the
                // loop has finished and it is safe to
                // dispose of the unmanaged resource.
                this.LoopFinishedMre.Set();
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                // Tell the worker that it needs
                // to break out of the loop.
                this.Scanning = false;
                // Block UI thread until Loop() has finished.
                this.LoopFinishedMre.WaitOne();
                // The loop has finished. It is safe to do cleanup.
                MessageBox.Show("It is now safe to dispose of the unmanaged resource.");
            }
        }
    }
