    static class Program
    {
        [STAThread]
        static void Main()
        {
            var handleCreated = new ManualResetEvent(false);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
