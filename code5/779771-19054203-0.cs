    protected void Dl1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || 
           e.Item.ItemType == ListItemType.AlternatingItem)
        {
            .... 
            Button SignupButton = (Button)e.Item.FindControl("SignupButton");
            if (Attending == 0)
            {
                SignupButton.Text = "Attend";
                SignupButton.Attributes.Add("class", "btn btn-large btn-success");
                SignupButton.CommandName = "Attend";
            }
            else
            {
                SignupButton.Text = "Remove";
                SignupButton.Attributes.Add("class", "btn btn-large btn-danger");
                SignupButton.CommandName = "Remove";
            }
        }
    }
    
    protected void Dl1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Attend")
        {
            Response.Redirect("Default.aspx?msg=work");
        }
        else if (e.CommandName == "Remove")
        {
            Response.Redirect("Default.aspx?msg=gone");
        }
    }
