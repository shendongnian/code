    private void RemoveMenuItem_Click(object sender, EventArgs e) {
      ToolStripMenuItem ti = sender as ToolStripMenuItem;
      ContextMenuStrip cs = ti.Owner as ContextMenuStrip;
      PictureBox pb = cs.SourceControl as PictureBox;
      MessageBox.Show(pb.Name);  // or pb.Dispose();
    }
