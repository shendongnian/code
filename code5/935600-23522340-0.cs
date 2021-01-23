    void toolStripLabel2_MouseDown(object sender, MouseEventArgs e) {
      Control c = new Control();
      c.MinimumSize = new Size(200, 200);      
      c.BackColor = Color.Green;
      ToolStripDropDown td = new ToolStripDropDown();
      td.Padding = Padding.Empty;
      ToolStripControlHost th = new ToolStripControlHost(c);
      th.Margin = Padding.Empty;
      td.Items.Add(th);
      td.Show(this.PointToScreen(new Point(toolStripLabel2.Bounds.Left,
                                           toolStripLabel2.Bounds.Bottom)));
    }
