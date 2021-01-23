    protected void r1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Header) 
            {
                object headeRow = e.Item.FindControl("tdInfoHeader");
                headeRow.Visible = false;
            }       
        } 
