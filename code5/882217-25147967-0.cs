    public class ValuesPanel : Panel
    {
        public int this[int x, int y] { get { return cells[x, y]; } set { cells[x, y] = value; } }
        private int[,] cells = new int[50, 50];
        const int cell_width = 15, cell_height = 15;
        private int x, y, scroll_x, scroll_y;
        public ValuesPanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            AutoScrollMinSize = new Size(50 * cell_width, 50 * cell_height);
            BorderStyle = BorderStyle.Fixed3D;
            Cursor = Cursors.Hand;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.DeepSkyBlue, x * cell_width - scroll_x, y * cell_height - scroll_y, cell_width, cell_height);
            for (int j = 0; j < 50; j++)
                for (int i = 0; i < 50; i++)
                {
                    int xx = i * cell_width - scroll_x, yy = j * cell_height - scroll_y;
                    e.Graphics.DrawString(cells[i, j].ToString(), Font, new SolidBrush(ForeColor), new PointF(3 + xx, 1 + yy));
                    e.Graphics.DrawLine(Pens.Gray, xx, yy, xx + cell_width - 2, yy);
                    e.Graphics.DrawLine(Pens.Gray, xx, yy + cell_height - 2, xx, yy);
                    e.Graphics.DrawLine(Pens.White, xx + 1, yy + cell_height - 1, xx + cell_width - 1, yy + cell_height - 1);
                    e.Graphics.DrawLine(Pens.White, xx + cell_width - 1, yy + 1, xx + cell_width - 1, yy + cell_height - 1);
                }
        }
        protected override void OnScroll(ScrollEventArgs se)
        {
            Invalidate();
            base.OnScroll(se);
            scroll_x = HorizontalScroll.Value;
            scroll_y = VerticalScroll.Value;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            x = Math.Min(49, (e.Location.X + scroll_x) / cell_width);
            y = Math.Min(49, (e.Location.Y + scroll_y) / cell_height);
            Invalidate();
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
                cells[x, y] = (cells[x, y] % 4) + 1;
            else if (e.Button == MouseButtons.Right)
                cells[x, y] = cells[x, y] < 2 ? 4 : cells[x, y] - 1;
        }
    }
