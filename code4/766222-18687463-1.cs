    static class Program
        {
            public static Form1 myForm1;
            
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                myForm1= new Form1 ();
                Application.Run(myForm1);
            }
            
        }
