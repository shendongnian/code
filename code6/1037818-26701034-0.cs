    Font lastSelectionFont = rtb.SelectionFont;
    Font lastFont = rtb.Font;
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
