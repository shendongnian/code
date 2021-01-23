    if (((IEnumerable)rptID.DataSource).Cast<object>().Count() == 1)
    {
        ((HtmlGenericControl)e.Item.FindControl("myLink")).Attributes
                                                     .Add("class", "Count1");
    }
