        List<string> Usernames = new List<string>();
        public Form1()
        {
            InitializeComponent();
    
            Usernames.Add("Paul");
            Usernames.Add("Elaine");
            Usernames.Add("Elliot");
            Usernames.Add("Matt");
            Usernames.Add("Brian");
    
            comboBox1.DataSource = Usernames;
            comboBox2.DataSource = Usernames;
    
        }
