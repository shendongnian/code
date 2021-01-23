    public HighlightableRTB GetRichTextBox()
    {
        HighlightableRTB rtb = null;
        TabPage starting = tabControl1.SelectedTab;
        if (starting != null)
        {
            rtb = starting.Controls[0] as HighlightableRTB;
        }
        
        if (rtb != null)
        {
            rtb.TextChanged += new EventHandler(txtBox_TextChanged);
            rtb.MouseClick += new MouseEventHandler(rtbh_MouseClick);
            //rtb.Select(rtb.Text.Length, 0);
            rtb.Font = new Font(rtb.Font.FontFamily, 12);
            rtb.Select(rtb.Text.Length, 0);
        }
        return rtb;
    }
