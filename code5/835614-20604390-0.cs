    protected void Dropdownlist1_Changed(object sender, EventArgs, e)
    {
        string labelTxt= Dropdownlist1.SelectedValue;
        if(labelTxt == label1.Text)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
        else if(labelTxt == label2.Text)
        {
            Panel1.Visible = false;
            Panel2.Visible = true;
        }
    
    }
