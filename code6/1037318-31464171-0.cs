     {
        if (CheckBox1.Checked)
        {Label1.Text = "Checked Apple"; }
        if (CheckBox1.Checked == false)
        {
            Label1.Text = "Unchecked Apple";
        }
    }
    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox2.Checked)
        { Label1.Text = "Checked Banana"; }
        if (CheckBox2.Checked == false)
        {
            Label1.Text = "Unchecked Banana";
        }
    }
