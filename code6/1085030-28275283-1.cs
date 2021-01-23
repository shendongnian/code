    static class Program {
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        [STAThread]
        static void Main() {
            if(mutex.WaitOne(TimeSpan.Zero, true)) {
                try
                {
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 Application.Run(new Form1());
                }
                finally
                {
                 mutex.ReleaseMutex();
                }
            } else {
                MessageBox.Show("only one instance at a time");
            }
        }
    }
