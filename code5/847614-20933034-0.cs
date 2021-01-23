    int visibleLabel = 1; // to define which one is to be made visible
    private void button1_Click(object sender, EventArgs e)
    {
        if (visibleLabel < 10)
        {
            Label label = this.Controls.Find("Label" + visibleLabel , true).FirstOrDefault() as Label;
            if (label != null) label.Visible = true;
            visibleLabel++;
        }
    }
