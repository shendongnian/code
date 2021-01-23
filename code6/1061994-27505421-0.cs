    private void FireEventOnLoad()
    {
    
        foreach (ListItem item in rblAmit.Items)
        {
            item.Attributes.Add("onclick", "javascript:DisplayAlert();");
        }
        if (rblAmit.Items.FindByText("Senior") != null)
        {
            rblAmit.Items.FindByText("Senior").Selected = true;
        }
    }
