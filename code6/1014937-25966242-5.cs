    using System;
    using System.Threading;
    using System.Windows.Forms;
    namespace FormClosingExample
    {
        public partial class Form1 : Form
        {
            private bool Scanning = true;
            private readonly object FormClosingLock = new object();
            private readonly ManualResetEvent LoopFinishedMre = new ManualResetEvent(false);
            public Form1()
            {
                this.InitializeComponent();
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
                    // Critical region: we can't have the value of
                    // Scanning change between the check and Invoke.
                    lock (this.FormClosingLock)
                    {
                        if (!this.Scanning)
                        {
                            // ObjectDisposedException prevented.
                            break;
                        }
                        // Some UI-bound action (progress reporting).
                        this.Invoke(new Action(() => this.Text = i.ToString()));
                    }
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
                // The goal of this lock is to ensure that
                // the value of Scanning cannot be changed
                // between Scanning check and this.Invoke
                // in the worker loop as that would likely
                // result in an ObjectDisposedException.
                lock (this.FormClosingLock)
                {
                    // Tell the worker that it needs
                    // to break out of the loop.
                    this.Scanning = false;
                }
                // Block UI thread until Loop() has finished.
                this.LoopFinishedMre.WaitOne();
                MessageBox.Show("It is now safe to dispose of the unmanaged resource.");
            }
        }
    }
