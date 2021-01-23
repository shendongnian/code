    public List<String> all_team = new List<string>
        {
            "Team A",
            "Team B"
        };
        public List<String> all_league = new List<string>
        {
            "League a",
            "League b"
        };
        public ComboBox combo_team = new ComboBox();   //global combo_team
        public ComboBox combo_league = new ComboBox();  //global combo_league
        public Form1()
        {
            InitializeComponent();
            comboBox1.Visible = false;
            
        }
        /// <summary>
        /// Method 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox) sender;
            comboBox1.DataSource = checkbox.Checked ? all_team : all_league;
            comboBox1.Visible = true;
        }
        /// <summary>
        /// Method2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            combo_league.DataSource = all_league;
            combo_team.DataSource = all_team;
            var checkbox = (CheckBox)sender;
            comboBox1.DataSource = checkbox.Checked?combo_league.DataSource:combo_team.DataSource;
            comboBox1.Visible = true;
        }
