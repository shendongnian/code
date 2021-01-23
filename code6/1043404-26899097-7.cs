    using System;
    using System.Windows.Forms;
    namespace ClassLibrary1
    {
        public class Program
        {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Form1 form = new Form1();
                Application.Run(form);
            }
        }
    }
