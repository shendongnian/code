    protected void ListView_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            DataTable table = (DataTable) e.Item.DataItem;
            GridView grid = (GridView) e.Item.FindControl("GridViewID");
            grid.DataSource = table;
            grid.DataBind();
        }
    }
