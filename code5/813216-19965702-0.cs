    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    namespace BuildFile
    {
      static class Program
      {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
          int ABCFile = -1;
          string[] args = Environment.GetCommandLineArgs();
          if ((args.Length > 1) && (args[1].StartsWith("/n")))
          {
                ... unrelated details omiited
                ABCFile = 1;
            }
          }
    
          if (ABCFile > 0)
          {
            var me = new MainForm(); // instantiate the form
            me.NoGui(ABCFile); // call the alternate entry point
            Environment.Exit(0);
          }
          else
          {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
          }
        }
      }
    }
