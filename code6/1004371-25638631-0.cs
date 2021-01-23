        List<string> strControlException = new List<string>();
        
        public Form1()
        {
            InitializeComponent();
            strControlException.Add("btnMain");
            strControlException.Add("txtMain");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count;i++ )
            {
                if (!strControlException.Contains(Controls[i].Name))
                {
                    Controls[i].Enter += new EventHandler(hideButton);
                }
            }
        }
        private void txtMain_Enter(object sender, EventArgs e)
        {
            btnMain.Visible = true;
        }
        private void hideButton(object sender, EventArgs e)
        {
            btnMain.Visible = false;
        }
