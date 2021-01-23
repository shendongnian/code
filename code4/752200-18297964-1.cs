    protected void YourListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        HtmlGenericControl myLi = (HtmlGenericControl)e.Item.FindControl("listItem");
        myLi.Attributes.Add("class", myLi.Attributes["class"].ToString() + " yournewclass");
    }
