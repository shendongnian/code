    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static Form1 f1;
        private static Form2 f2;
        public static Form1 F1
        {
            get
            {
                if (f1 == null || f1.IsDisposed)
                {
                    f1 = new Form1();
                }
                return f1;
            }
        }
        public static Form2 F2
        {
            get
            {
                if (f2 == null || f2.IsDisposed)
                {
                    f2 = new Form2();
                }
                return f2;
            }
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Program.F1);
        }
    }
