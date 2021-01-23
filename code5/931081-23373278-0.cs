    if (repID.DataSource.Count == 1)
    {
        ((HtmlGenericControl)e.Item.FindControl("myLink")).Attributes
                                                     .Add("class", "Count1");
    }
