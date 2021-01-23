    //[Program.cs] 
    using System;
    using System.Windows.Forms;
    using DevExpress.XtraEditors;
    
    namespace WindowsFormsApplication8 {
        static class Program {
            /// <summary> 
            /// The main entry point for the application. 
            /// </summary> 
            [STAThread]
            static void Main() {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                
                //Enable title bar skinning
                WindowsFormsSettings.EnableFormSkins();
                WindowsFormsSettings.EnableMdiFormSkins();
                Application.Run(new Form1());
            }
        }
    }
