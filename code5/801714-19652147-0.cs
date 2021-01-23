      static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form f = new Form1(); //this contains some Telerik WinForms controls
            Telerik.WinControls.RadMessageBox.SetThemeName("TelerikMetro");
            Telerik.WinControls.RadMessageBox.Show("test");
            Application.Run(f);
        }
