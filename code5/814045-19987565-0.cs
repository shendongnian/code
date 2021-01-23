        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // silent mode - you don't need to instantiate any forms
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
