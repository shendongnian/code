        [STAThread]
        static void Main(string[] Args)
        {
             // here I suppose you pass as first parameter this flag to signal 
             // you intention to process from command line, of course change it as you like
             if(args != null && args[0] == "/autosendmail")
             {
                  // Start the processing of your command line params
                  
             }
             else
             {
                 Application.EnableVisualStyles();
                 Application.SetCompatibleTextRenderingDefault(false);
                 Application.Run(new frmMain());
             }
        }
