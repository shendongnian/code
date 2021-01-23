        public MainWindow()
        {
            InitializeComponent();
           
            listView1.View = View.Details;
            listView1.Columns.Add("Key");
            listView1.Columns.Add("Value");
            this.listView1.FullRowSelect = true;
            //register the process event
            this.listView1.SelectedIndexChanged += this.listView1_SelectedIndexChanged;
            //load data
            LoadListView();
            //test item selection
            ToSelectItem(0);
        }
        void ToSelectItem(int itemIndex)
        {
            if (itemIndex > listView1.Items.Count - 1)
                return;
            listView1.Focus();
            listView1.Select();
            listView1.Items[itemIndex].Focused = true;
            listView1.Items[itemIndex].Selected = true;
        }
        private void LoadListView()
        {
            // Create Dictionary, Keys = Ids, Values = Names
            Dictionary<int, string> ff_names = new Dictionary<int, string>();
            ff_names.Add(0, "Cloud");
            ff_names.Add(1, "Barret");
            ff_names.Add(2, "Tifa");
            ff_names.Add(3, "Aerith");
            ff_names.Add(4, "Red XIII");
            // Populating ListView
            foreach (KeyValuePair<int, string> dict in ff_names)
            {
                ListViewItem lvi = new ListViewItem(new string[] { dict.Key.ToString(), dict.Value });
                listView1.Items.Add(lvi);
            }
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                label1.Text = (string)listView1.SelectedItems[0].Text; // sadly, it's equal to 0;
                textBox1.Text = (string)listView1.SelectedItems[0].SubItems[1].Text;
            }
        }
