        public Form1()
        {
            InitializeComponent();
        }
        private Point _cellClick;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var h = dataGridView1.Rows[0].Height;
            if (MousePosition.Y % h == 0)
            {
                _cellClick = new Point(MousePosition.X, MousePosition.Y);
            }
            else
            {
                var y = MousePosition.Y;
                do
                {
                    y++;
                } while (y % 22 != 0);
                _cellClick = new Point(MousePosition.X, y);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var f = new Form2(_cellClick);
            f.ShowDialog(this);
        }
