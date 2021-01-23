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
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);
            lstClosedForms = new List<string>();
            Application.Run(new Form1());           
        }
        static void Application_ApplicationExit(object sender, EventArgs e)
        {
               if (DialogResult.OK == MessageBox.Show("Are You Sure To Exit?", "ExitConfirmation", MessageBoxButtons.OKCancel))
               {
                     ActivityRegistration(UserId, lstClosedForms); // 2nd argument changed to List<string>
             
                    if (System.Windows.Forms.Application.MessageLoop)              
                          System.Windows.Forms.Application.Exit();               
                    else               
                          System.Environment.Exit(1);               
                }
         }
    }    
