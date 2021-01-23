    object myItem;
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.Add("Paul");
            listBox1.Items.Add("George");
            listBox1.Items.Add("Nik");
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            myItem = listBox1.SelectedItem;
            listBox2.Items.Add(myItem);
        }
