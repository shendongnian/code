        static List<string> Usernames = new List<string>();
        public static Form1()
        {
            Usernames.Add("Paul");
            Usernames.Add("Elaine");
            Usernames.Add("Elliot");
            Usernames.Add("Matt");
            Usernames.Add("Brian");
        }
    
        public Form1()
        {
            InitializeComponent();
    
            comboBox1.DataSource = Usernames;
            comboBox2.DataSource = Usernames;
   
        }
