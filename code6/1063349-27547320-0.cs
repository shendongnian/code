    public Form1()
        {
            InitializeComponent();
            DataGridViewComboBoxColumn cmbcolumn = new DataGridViewComboBoxColumn();
            dataGridView2.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView2_EditingControlShowing);
        }
        private void dataGridView2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            string item = cb.Text;
            if (item == "Add")
            {
                Categorie cat = new Categorie();
                cat.Show();
            }
        }
