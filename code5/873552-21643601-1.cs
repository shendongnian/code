    void Main()
    {
        var c = new UserControl();
        var chkBold = new CheckBox();
        var chkItalic = new CheckBox();
        var chkUnderline = new CheckBox();
        var tb = new TextBox();
        c.Controls.AddRange(new Control[] { chkBold, chkItalic, chkUnderline, tb });
    
        chkBold.Location = new Point(8, 8);
        chkBold.Text = "Bold";
        chkBold.CheckedChanged += (sender, e) =>
        {
            var style = tb.Font.Style & ~FontStyle.Bold;
            if (chkBold.Checked)
                style |= FontStyle.Bold;
            tb.Font = new Font(tb.Font, style);
        };
    
        chkItalic.Location = new Point(8, 32);
        chkItalic.Text = "Italic";
        chkItalic.CheckedChanged += (sender, e) =>
        {
            var style = tb.Font.Style & ~FontStyle.Italic;
            if (chkItalic.Checked)
                style |= FontStyle.Italic;
            tb.Font = new Font(tb.Font, style);
        };
    
        chkUnderline.Location = new Point(8, 56);
        chkUnderline.Text = "Underline";
        chkUnderline.CheckedChanged += (sender, e) =>
        {
            var style = tb.Font.Style & ~FontStyle.Underline;
            if (chkUnderline.Checked)
                style |= FontStyle.Underline;
            tb.Font = new Font(tb.Font, style);
        };
    
        tb.Location = new Point(8, 80);
        tb.Text = "Try it";
    
        c.Dump();
    }
