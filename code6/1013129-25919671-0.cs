    using System;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
     
    namespace SuperSingleInstance
    {
        static class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string[] args = Environment.GetCommandLineArgs();
                SingleInstanceController controller = new SingleInstanceController();
                controller.Run(args);
            }
        }
    
        public class SingleInstanceController : WindowsFormsApplicationBase
        {
            public SingleInstanceController()
            {
                IsSingleInstance = true;
                 
                StartupNextInstance += this_StartupNextInstance;
            }
 
            void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
            {
                Form1 form = MainForm as Form1; //My derived form type
                form.LoadFile(e.CommandLine[1]);
            }
             
            protected override void OnCreateMainForm()
            {
                MainForm = new Form1();
            }
        }
    }
