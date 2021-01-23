    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        TextBox txtrshte = (TextBox)chk.Parent.FindControl("TextBox8");
        DropDownList drpreshte = (DropDownList)chk.Parent.FindControl("DropDownList2");
    
        if (chk.Checked)
        {
            txtrshte.Visible = true;
            drpreshte.Visible = false;
    
        }
    }
