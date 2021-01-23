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
            // look for the following 2 lines
            var valuesGenerator = new ValuesGenerator();
            List<Values> values = valuesGenerator.GetColumnInfo(); // This is the list which contains the deserialized info
            Application.Run(new class1());
        }
    }
