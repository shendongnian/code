    public static void AddContextMenu(this RichTextBox rtb)
    {
        if (rtb.ContextMenuStrip == null)
        {
            ContextMenuStrip cms = new ContextMenuStrip()
            {
                ShowImageMargin = false
            };
            ToolStripMenuItem tsmiCut = new ToolStripMenuItem("Cut");
            tsmiCut.Click += (sender, e) => rtb.Cut();
            cms.Items.Add(tsmiCut);
            ToolStripMenuItem tsmiCopy = new ToolStripMenuItem("Copy");
            tsmiCopy.Click += (sender, e) => rtb.Copy();
            cms.Items.Add(tsmiCopy);
            ToolStripMenuItem tsmiPaste = new ToolStripMenuItem("Paste");
            tsmiPaste.Click += (sender, e) => rtb.Paste();
            cms.Items.Add(tsmiPaste);
            cms.Opening += (sender, e) =>
            {
                tsmiCut.Enabled = !rtb.ReadOnly && rtb.SelectionLength > 0;
                tsmiCopy.Enabled = rtb.SelectionLength > 0;
                tsmiPaste.Enabled = !rtb.ReadOnly && Clipboard.ContainsText();
            };
            rtb.ContextMenuStrip = cms;
        }
    }
