     linkedMenuItem.Click += (sender, e) => linkedMenuItem.Checked = !linkedMenuItem.Checked;
     linkedMenuItem.CheckedChanged +=
         (sender, e) =>
         {
             if (linkedMenuItem.Tag is ToolStripMenuItem)
             {
                 ((ToolStripMenuItem)linkedMenuItem.Tag).Visible = linkedMenuItem.Checked;
             }
         };
