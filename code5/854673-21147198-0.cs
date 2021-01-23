    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;   // Add reference to Microsoft.VisualBasic
    
    namespace MyApp
    {
      class Program : WindowsFormsApplicationBase 
      {
         /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
          var app = new Program();
          app.Run(args);
        }
        public Program()
        {
          this.IsSingleInstance = true;
          this.EnableVisualStyles = true;
          this.MainForm = new fMain();
        }
        protected override void OnStartupNextInstance(StartupNextInstanceEventArgs eventArgs)
        {
          if (this.MainForm.WindowState == FormWindowState.Minimized) {
            this.MainForm.Show();     // Unhide if hidden
            this.MainForm.WindowState = FormWindowState.Normal; //Restore
          }
          this.MainForm.Activate();
        }
      }
    
    }
