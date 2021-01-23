     linkedMenuItem.Click += (sender, e) => linkedMenuItem.Checked = !linkedMenuItem.Checked;
     linkedMenuItem.CheckedChanged +=
         (sender, e) =>
         {
             var linkedToolStripItem = linkedMenuItem.Tag as ToolStripItem;
             if (linkedToolStripItem != null)
             {
                 linkedToolStripItem.Visible = linkedMenuItem.Checked;
             }
         };
