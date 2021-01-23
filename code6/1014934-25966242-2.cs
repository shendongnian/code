    using System;
    using System.Threading;
    using System.Windows.Forms;
    namespace FormClosingExample
    {
        public partial class Form1 : Form
        {
            // Try it without "volatile" in Release
            // configuration. You'll be surprised.
            private volatile bool IsClosing;
            private readonly object FormClosingLock = new object();
            private readonly ManualResetEvent LoopFinishedMre = new ManualResetEvent(false);
            public Form1()
            {
                this.InitializeComponent();
                new Thread(this.Loop).Start();
            }
            private void Loop()
            {
                int i = 0;
                while (true)
                {
                    // Simulate time-consuming operation on unmanaged resource.
                    i++;
                    Thread.Sleep(1000);
                    lock (this.FormClosingLock)
                    {
                        // The below check is optimised away in Release
                        // configuration unless the field is declared as volatile
                        // (thus you would get a deadlock on the Invoke).
                        if (this.IsClosing)
                        {
                            break;
                        }
                        // Some UI-bound action.
                        this.Invoke(new Action(() => this.Text = i.ToString()));
                    }
                }
                this.LoopFinishedMre.Set();
            }
            private void Form1_FormClosing(object sender, FormClosingEventArgs e)
            {
                lock (this.FormClosingLock)
                {
                    this.IsClosing = true;
                }
                // Block UI thread until Loop() has finished.
                this.LoopFinishedMre.WaitOne();
                MessageBox.Show("This is where you would dispose of the unmanaged resource.");
            }
        }
    }
