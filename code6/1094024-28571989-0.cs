    TabPage tp = new TabPage("New Document");
    RichTextBox rtb = new RichTextBox();
    rtb.Dock = DockStyle.Fill;
    ContextMenuStrip ctx = new ContextMenuStrip();
    ctx.Items.Add(new ToolStripMenuItem("Cut",null, cutClick));
    ctx.Items.Add(new ToolStripMenuItem("Copy", null, copyClick))
    ctx.Items.Add(new ToolStripMenuItem("Paste", null, pasteClick));
    // Add other menu items as you need
    rtb.ContextMenuStrip = ctx;
    .....
    void cutClick(object sender, EventArgs e)
    {
        RichTextBox rtb = sender as RichTextBox;
        if(rtb.SelectedText.Length > 0)
            rtb.Cut();
    }
    void copyClick(object sender, EventArgs e)
    {
        RichTextBox rtb = sender as RichTextBox;
        if(rtb.SelectedText.Length > 0)
           rtb.Copy();
    }
    void pasteClick(object sender, EventArgs e)
    {
        RichTextBox rtb = sender as RichTextBox;
        DataFormats.Format textFormat = DataFormats.GetFormat(DataFormats.Text);
        if(rtb.CanPaste(textFormat))
            rtb.Paste();
    }
    
