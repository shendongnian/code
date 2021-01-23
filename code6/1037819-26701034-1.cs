    public Form1()
    {
        InitializeComponent();
        lastSelectionFont = rtb.SelectionFont;
        lastFont = rtb.Font;
        //..
    }
    Font lastSelectionFont;
    Font lastFont;
    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        RichTextBox rtb = richTextBox1;
        ComboBox combo_sizes = new ComboBox();
        if (rtb.SelectionLength > 0)
        {
            lastSelectionFont = rtb.SelectionFont;
            rtb.SelectionFont = new Font(rtb.SelectionFont.FontFamily, 
                                    Convert.ToInt16(combo_sizes.Text));
        }
        else
        {
            lastFont = rtb.Font;
            rtb.Font = new Font(rtb.Font.FontFamily, 
                                   Convert.ToInt16(combo_sizes.Text));
        }
    }
