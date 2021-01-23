        //CellPainting event handler for your dataGridView1
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e){
            if (e.RowIndex == -1 && e.ColumnIndex > -1){
                e.PaintBackground(e.CellBounds, true);
                RenderColumnHeader(e.Graphics, e.CellBounds, e.CellBounds.Contains(hotSpot) ? hotSpotColor : backColor);
                RenderColumnHeaderBorder(e.Graphics, e.CellBounds, e.ColumnIndex);
                e.PaintContent(e.CellBounds);
                e.Handled = true;
            }
        }
        Color hotSpotColor = Color.LightGreen;//For hover backcolor
        Color backColor = Color.LimeGreen;    //For backColor    
        Point hotSpot;
        private void RenderColumnHeader(Graphics g, Rectangle headerBounds, Color c) {
            int topHeight = 10;
            Rectangle topRect = new Rectangle(headerBounds.Left, headerBounds.Top+1, headerBounds.Width, topHeight);
            RectangleF bottomRect = new RectangleF(headerBounds.Left, headerBounds.Top+1 + topHeight, headerBounds.Width, headerBounds.Height- topHeight-4);            
            Color c1 = Color.FromArgb(180, c);            
            using (SolidBrush brush = new SolidBrush(c1)) {
                g.FillRectangle(brush, topRect);
                brush.Color = c;
                g.FillRectangle(brush, bottomRect);
            }
        }
        private void RenderColumnHeaderBorder(Graphics g, Rectangle headerBounds, int colIndex) {            
            g.DrawRectangle(new Pen(Color.White, 0.1f), headerBounds.Left + 0.5f, headerBounds.Top + 0.5f,headerBounds.Width-1f,headerBounds.Height-1f);
            ControlPaint.DrawBorder(g, headerBounds, Color.Gray, 0, ButtonBorderStyle.Inset,
                                                   Color.Gray, 0, ButtonBorderStyle.Inset,
                                                 Color.Gray, colIndex != dataGridView1.ColumnCount - 1 ? 1 : 0, ButtonBorderStyle.Inset,
                                               Color.Gray, 1, ButtonBorderStyle.Inset);
        }
        //MouseMove event handler for your dataGridView1
        private void dataGridView1_MouseMove(object sender, MouseEventArgs e){
            hotSpot = e.Location;
        }
        //MouseLeave event handler for your dataGridView1
        private void dataGridView1_MouseLeave(object sender, EventArgs e){
            hotSpot = Point.Empty;
        }
