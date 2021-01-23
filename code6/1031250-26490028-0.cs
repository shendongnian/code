    private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
      Control c = ((ContextMenuStrip)((ToolStripMenuItem)sender).Owner).SourceControl;
      if (c != null) {
        // do something...
      }
    }
