        private Utility Tool { get; set; }
        public Form() {
            InitializeComponent();
            Tool = new Utility();
        }
        private void button1_Click(object sender, EventArgs e) {
            Tool.StoreActiveUser(Int32.Parse(textBox1.Text), textBox2.Text);
            // ...
