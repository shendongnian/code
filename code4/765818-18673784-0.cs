     protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
     {
        if (e.Item.ItemType == ListItemType.Item ||
             e.Item.ItemType == ListItemType.AlternatingItem)
        {           
            GridView grd= (GridView )e.Item.FindControl("GridView1"); 
            grd.DataSource = dt;
            grd.DataBind();
        }
     }
