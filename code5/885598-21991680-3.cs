    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using ****your DLL namespace here****
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
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new [****your startup form (from the DLL) here****]);
            }
        }
    }
