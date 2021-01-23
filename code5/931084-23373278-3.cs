    var rpt = Page.FindControl("rptID") as Repeater;
    if (rpt != null && rpt.DataSource != null && ((IEnumerable)rpt.DataSource).Cast<object>().Count() == 1)
    {
        ((HtmlGenericControl)e.Item.FindControl("myLink")).Attributes
                                                     .Add("class", "Count1");
    }
