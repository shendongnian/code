    namespace WindowsFormsApplication1
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
                Application.Run(new Form1());
            }
            public class BaseClass
            {
            }
            public class DerivedClass : BaseClass
            {
            }
            interface IExampleInterface
            {
            }
            public class ProgramMain
            {
            }
        }
    }
