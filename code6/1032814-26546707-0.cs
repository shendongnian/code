         ToolStripButton b = new ToolStripButton();
     b.ImageIndex = ((ToolStripButton)((ToolStrip)dlgPreview.Controls[1]).Items[0]).ImageIndex;
           
            ((ToolStrip)dlgPreview.Controls[1]).Items.Remove(((ToolStripButton)((ToolStrip)dlgPreview.Controls[1]).Items[0]));
            b.Visible = true;
            ((ToolStrip)dlgPreview.Controls[1]).Items.Insert(0, b);
            ((ToolStripButton)((ToolStrip)dlgPreview.Controls[1]).Items[0]).Click += new System.EventHandler(this.button1_Click);
