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
            Form1 form1 = new Form1(); 
            Form1 form2 = new Form2(); 
            Application.Run(form1);
           // It will run form1 until it close then run the form2 
            Application.Run(form2);
        }
    }
}
