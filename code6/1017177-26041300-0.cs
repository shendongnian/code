    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    namespace WindowsFormsApplication1
    {
      public class Startup : WindowsFormsApplicationBase
      {
        protected override void OnCreateSplashScreen()
        {
          SplashScreen = new logo();
        }
        protected override void OnCreateMainForm()
        {
          MainForm = new Form1();
        }
      }
      static class Program
      {
        [STAThread]
        static void Main()
        {
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          new Startup().Run(new string[]{});
        }
      }
    }
