    label1.MouseClick += new EventHandler(this.AllLable_MouseClick);
    label2.MouseClick += new EventHandler(this.AllLable_MouseClick);
    label3.MouseClick += new EventHandler(this.AllLable_MouseClick);
    private void AllLable_MouseClick(object sender, MouseEventArgs e)
    {
        Label lbl = (Label)sender;
        if (lbl.BorderStyle == BorderStyle.FixedSingle)
            lbl.BorderStyle = BorderStyle.None
        else
            lbl.BorderStyle = BorderStyle.FixedSingle
    }
