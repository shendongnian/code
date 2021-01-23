     static void Main(string[] args)
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmSplashScreen());
                if (args.Length > 0)
                    Application.Run(new frmMain(args[0]));
                else
                    Application.Run(new frmMain());
            }
            catch(Exception ex)
            {
               while(ex!=null)
               {
                   MessageBox.Show(ex.Message);
                   ex = ex.InnerException;
               }
            }
        }
