        public Form1()
        {
            InitializeComponent();
        }
        Point cellClick;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cellClick = new Point(MousePosition.X, MousePosition.Y);
        }
        private void myButton_Click(object sender, EventArgs e)
        {
            var f = new Form2(cellClick);
            f.Show(this);
        }
        public Form2(Point loc)
        {
            InitializeComponent();
            Location = loc;
        }
