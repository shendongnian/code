    protected void repeatComment_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var userComment = e.Item.FindControl("userComment") as Label;
            }
        }
 
