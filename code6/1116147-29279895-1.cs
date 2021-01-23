    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            string file = Path.Combine(path, "EULA.txt");
            if (File.Exists(file))
            {
                var form1 = new Form1();
                form1.Closed += (s, args) => this.Close();
                form1.Show();
            }
            else 
            {
                var eula = new EULA();
                eula.Show();
            }
        }
    }
