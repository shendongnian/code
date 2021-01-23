    if (rptID.Items.Count == 1)
    {
        ((HtmlGenericControl)e.Item.FindControl("myLink")).Attributes
                                                     .Add("class", "Count1");
    }
