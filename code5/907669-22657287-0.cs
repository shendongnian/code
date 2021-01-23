    protected void rptBreadCrumb_DataBound(Object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            LinkButton lnkBrdCrmb = (LinkButton)e.Item.FindControl("lnkBrdCrmb");
            // get the anonymous type's properties via DataBinder.Eval
            string text = (string)DataBinder.Eval(e.Item.DataItem, "Text");
            string url = (string)DataBinder.Eval(e.Item.DataItem, "Url");
            lnkBrdCrmb.Text = text;
            lnkBrdCrmb.PostBackUrl = url;
        }
    }
