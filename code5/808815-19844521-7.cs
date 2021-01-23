        public Form1()
        {
            InitializeComponent();
        }
        private Point _cellClick;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _cellClick = new Point(MousePosition.X, MousePosition.Y);            
        }
        private void myButton_Click(object sender, EventArgs e)
        {
            var f = new Form2(_cellClick);
            f.ShowDialog(this);
        }
