    item1ToolStripMenuItem.Click += new System.EventHandler(ToolStripMenuItem_Click);
    item2ToolStripMenuItem.Click += new System.EventHandler(ToolStripMenuItem_Click);
    item3ToolStripMenuItem.Click += new System.EventHandler(ToolStripMenuItem_Click);
    private void ToolStripMenuItem_Click(object sender, EventArgs e)
    {
      comboBox1.SelectedIndex = comboBox1.FindString(((ToolStripMenuItem)sender).Text);
    }
