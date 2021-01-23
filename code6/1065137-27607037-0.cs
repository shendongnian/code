        private int prevIndex = -1;
        private void listBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(listBox1.PointToClient(Cursor.Position));
            if (index != prevIndex)
            {
                prevIndex = index;
                listBox1.Invalidate();
            }
        }
        private void listBox1_MouseLeave(object sender, EventArgs e)
        {
            prevIndex = -1;
            listBox1.Invalidate();
        }
        private void DrawListBox(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Color c;
            if (e.Index == prevIndex )
            {
                c = Color.Yellow; // whatever the "highlight" color should be
            }
            else if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                c = Color.FromArgb(52, 146, 204); 
            }
            else
            {
                c = e.BackColor;
            }
            using (SolidBrush brsh = new SolidBrush(c))
            {
                g.FillRectangle(brsh, e.Bounds);
            }
            using (SolidBrush brsh = new SolidBrush(e.ForeColor))
            {
                g.DrawString(listBox1.Items[e.Index].ToString(), e.Font,
                 brsh, e.Bounds, StringFormat.GenericDefault);
            }
            
            e.DrawFocusRectangle();
        }
