    internal static class Program
    {
        private static readonly MyPeriodicUploader _myPeriodicUploader = new MyPeriodicUploader();
        public static MyPeriodicUploader MyPeriodicUploader
        {
            get { return _myPeriodicUploader; }
        }
        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
