    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(DropDownList5.SelectedValue == "decimal")
        {
            TextBox1.Text = dr.GetString(0);
        }
        else if(DropDownList5.SelectedValue == "int")
        { 
            Label1.Text = dr.GetString(0);
        }
        else if(DropDownList5.SelectedValue == "varchar")
        {
            Button1.Text = dr.GetString(0);
        }
    }
