    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace WindowsFormsApplication2
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Form1 form = null;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                BackgroundWorker workerThread = new BackgroundWorker();
                workerThread.DoWork += delegate
                {
                    Thread.Sleep(1500);
                };
                workerThread.RunWorkerCompleted += delegate
                {
                    if ( form != null )
                        form.BackColor = Color.Red;
                };
                workerThread.RunWorkerAsync();
                form = new Form1();
                Application.Run(form);
            }
        }
    }
