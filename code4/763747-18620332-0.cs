        Dictionary<int, string> Test1 = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            Test1.Add(1, "asdf");
            Test1.Add(2, "ghjh");
            Test1.Add(3, "jkl;");
            Test1.Add(4, "qwer");
            int max = 4;
            int min = 1;
            listBox1.DataSource = (from kvp in Test1
                                   where (kvp.Key > min && kvp.Key < max)
                                   select (kvp.Value)).ToList();
        }
