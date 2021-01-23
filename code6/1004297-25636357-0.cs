    static class Program
    {
        static public List<string> lstClosedForms;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            lstClosedForms = new List<string>();
            Application.Run(new Form1());           
        }
    }
