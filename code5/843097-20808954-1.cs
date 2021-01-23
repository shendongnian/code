    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            MyClass main = new MyClass();
            if (main.CheckConditions()) {
                MyClassApplicationContext context = new MyClassApplicationContext();
                Application.Run(context);
            }
        }
    }
