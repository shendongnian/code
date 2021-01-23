    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main ()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MyApplicationContext context = new MyApplicationContext();
            Application.Run(context);
        }
        public class MyApplicationContext : ApplicationContext
        {
            private Form1 form1 = new Form1();
            public MyApplicationContext ()
            {
                form1 = new Form1();
                form1.Show();
            }
        }
    }
