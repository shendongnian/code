    static class Program
    {
        static DateTime expiration = new DateTime(2013, 10, 31);
        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (DateTime.Today < expiration.Date) 
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                Application.Exit();
            }
        }
    }
