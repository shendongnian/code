    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            String user = null;
            using (var login = new loginForm())
            {
                
                bool invalid = login.ShowDialog() != DialogResult.OK; 
                user = login.returnUser();
                if(invalid)
                   return;
            }
            Application.Run(new Form1(user));
        }
