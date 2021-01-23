            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // add this line
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
            Application.Run(new Form1());
