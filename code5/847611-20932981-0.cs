    private void button1_Click(object sender, EventArgs e)
    {
        foreach(Control c in this.Controls)
        {
            if(c is Label)
               c.Visible = true;
        }
    }
