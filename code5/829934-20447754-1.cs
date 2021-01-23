        public Form1() {
            InitializeComponent();
            listView1.View = View.Details;
            listView1.Columns.Add("Key");
            listView1.Columns.Add("Value");
            LoadListView();
        }
        private void LoadListView() {
            // Create Dictionary, Keys = Ids, Values = Names
            Dictionary<int, string> ff_names = new Dictionary<int, string>();
            ff_names.Add(0, "Cloud");
            ff_names.Add(1, "Barret");
            ff_names.Add(2, "Tifa");
            ff_names.Add(3, "Aerith");
            ff_names.Add(4, "Red XIII");
            // Populating ListView
            foreach (KeyValuePair<int, string> dict in ff_names) {
                ListViewItem lvi = new ListViewItem(new string[] { dict.Key.ToString(), dict.Value });
                listView1.Items.Add(lvi);
            }
            // Test Item Selection
            listView1.Focus();
            listView1.Select();
            listView1.Items[0].Focused = true;
            listView1.Items[0].Selected = true;
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {
            if (listView1.SelectedItems.Count > 0) {
                label1.Text = (string)listView1.SelectedItems[0].Text; // sadly, it's equal to 0;
                textBox1.Text = (string)listView1.SelectedItems[0].SubItems[1].Text;
            }
        }
