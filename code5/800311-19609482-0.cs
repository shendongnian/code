      public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                ComboboxItem item = new ComboboxItem("John", i);
                comboBox1.Items.Add(item);
               
                
                
            }
            comboBox1.DisplayMember = "Name";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboboxItem item = (ComboboxItem)comboBox1.SelectedItem;
            MessageBox.Show(item.ID.ToString());
        }
