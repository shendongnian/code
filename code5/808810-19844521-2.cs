        public Form1()
        {
            InitializeComponent();
        }
        Point cellClick;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rectangle = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
            cellClick = new Point(rectangle.Bottom, rectangle.Left);
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
