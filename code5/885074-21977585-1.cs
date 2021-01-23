    private void btnBold_Click(object sender, EventArgs e)
    {
        if (rtf.SelectionFont.Bold)
        {
            rtf.SelectionFont = new Font(
                rtf.SelectionFont.FontFamily,
                rtf.SelectionFont.Size,
                rtf.SelectionFont.Style ^ FontStyle.Bold);
        }
        else
        {
            rtf.SelectionFont = new Font(
                rtf.SelectionFont.FontFamily,
                rtf.SelectionFont.Size,
                rtf.SelectionFont.Style | FontStyle.Bold);
        }
    }
    
    private void btnItalic_Click(object sender, EventArgs e)
    {
        if (rtf.SelectionFont.Italic)
        {
            rtf.SelectionFont = new Font(
                rtf.SelectionFont.FontFamily,
                rtf.SelectionFont.Size,
                rtf.SelectionFont.Style ^ FontStyle.Italic);
        }
        else
        {
            rtf.SelectionFont = new Font(
                rtf.SelectionFont.FontFamily,
                rtf.SelectionFont.Size,
                rtf.SelectionFont.Style | FontStyle.Italic);
        }
    }
