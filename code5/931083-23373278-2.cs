    var rpt = Page.FindControl("rptID") as Repeater;
    if (rpt != null && rpt.DataSource != null && rpt.DataSource.ToList().Count == 1)
    {
        ((HtmlGenericControl)e.Item.FindControl("myLink")).Attributes
                                                     .Add("class", "Count1");
    }
