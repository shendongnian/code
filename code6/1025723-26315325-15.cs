        private void cb_addPage_Click(object sender, EventArgs e)
        {
            string title = "TabPage " + (tabControl1.TabCount + 1).ToString() + "   ";
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedTab = myTabPage;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            cb_addPage.Top = tabControl1.Top;
            cb_addPage.Left = tabControl1.Right - cb_addPage.Width;
            foreach (TabPage tp in tabControl1.TabPages) tp.Text += "   ";
        }
        Rectangle closeX = Rectangle.Empty;
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Size xSize = new Size(13,13);
            TabPage tp = tabControl3.TabPages[e.Index];
            e.DrawBackground();
            using (SolidBrush brush = new SolidBrush(e.ForeColor)  )
                   e.Graphics.DrawString(tp.Text+ "   ", e.Font,  brush, 
                                         e.Bounds.X + 3, e.Bounds.Y + 4 );
            if (e.State == DrawItemState.Selected)
            {
               closeX = new Rectangle(
                   e.Bounds.Right - xSize.Width, e.Bounds.Top, xSize.Width, xSize.Height);
               using (SolidBrush brush = new SolidBrush(Color.LightGray))
                    e.Graphics.DrawString("x", e.Font, brush, 
                                           e.Bounds.Right - xSize.Width, e.Bounds.Y + 4);
            }
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (closeX.Contains(e.Location))
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }
