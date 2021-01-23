    static class Variables
    {
        public static DataSet Configurations = new DataSet();
        public static float ExchangeRate = 0;
        public static Dictionary<string, int> ItemsCategories = new Dictionary<string, int>();
        public static Dictionary<string, float> WeightUnits = new Dictionary<string, float>();
    }
    static class Forms
    {
        public static Form2 F_Form2 = new Form2();
        
        public static Form3 F_Form3 = new Form3();
    }
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
