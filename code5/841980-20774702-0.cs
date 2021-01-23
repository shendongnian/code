    private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
    {
        DataGridView.HitTestInfo info = dataGridView1.HitTest(e.X, e.Y); //get info
        int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;
        if (e.Button == MouseButtons.Right) //MouseButton right: Open context menu strip.
         {
             dataGridView1.Rows[currentMouseOverRow].Selected = true; //Select the row
             _myMenu = new ContextMenuStrip();
             ToolStripMenuItem MenuOpenPO = new ToolStripMenuItem("Delete it");
             MenuOpenPO.Click += new EventHandler(MenuOpenPO_Click);
             _myMenu.Items.AddRange(new ToolStripItem[] { MenuOpenPO });
             _myMenu.Show(new Point(e.X, e.Y));
         }
    }
