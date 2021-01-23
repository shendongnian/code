    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetValue(2);
       Label1.Text = string.Format("hello{0}", GetValue());
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetValue(2);
        Label1.Text = string.Format("hello{0}", GetValue());
    }
    
