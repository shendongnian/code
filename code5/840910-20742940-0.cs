    protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox2.Visible = false;
        DropDownList2.Visible = true;
        CheckBox3.Visible = true;
        Label2.Text += "-" + DropDownList2.Text;
    }
    
    protected void CheckBox3_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox3.Visible = false;
        DropDownList3.Visible = true;
        CheckBox4.Visible = true;
        Label2.Text += "-" + DropDownList3.Text;
    }
