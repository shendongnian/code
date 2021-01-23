    protected void rptrHeatingNavien_ItemDataBound(object sender, EventArgs e)
    {
        if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var item = (SuperItem) e.Item.DataItem;
            var link = (HyperLink) e.Item.FindControl("productLink");
            link.NavigateUrl = string.Format("/Products/?Id={0}", item[0].ToString());
            link.Text = item[1].ToString();
        }
    }
