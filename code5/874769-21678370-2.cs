        [STAThread]
        static void Main(string[] Args)
        {
             // Here I suppose you pass, as first parameter, this flag to signal 
             // your intention to process from command line, 
             // of course change it as you like
             if(args != null && args[0] == "/autosendmail")
             {
                  // Start the processing of your command line params
                  ......
                  // At the end the code falls out of the main and exits    
             }
             else
             {
                 // No params passed on the command line, open the usual UI interface
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 Application.Run(new frmMain());
             }
        }
