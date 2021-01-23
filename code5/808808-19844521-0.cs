        public Form1()
        {
            InitializeComponent();
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            var point = new Point(MousePosition.X, MousePosition.Y);
            var f = new Form2(point);
            f.Show();
        }
        public Form2(Point loc)
        {
            InitializeComponent();
            Location = loc;
        }
