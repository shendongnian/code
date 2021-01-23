    protected void rMainCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = e.Item.DataItem as DataRowView;
            Repeater rSubCategories = e.Item.FindControl("rSubCategories") as Repeater;
            // save MainCatID in rMainCategories
            Label lblMainCatID=(Label)e.Item.FindControl(lblMainCatID);
        
         DataTable subcat=(DataTable)Session[subcategory];
        rSubCategories.DataSource = dt;        // filter subcate with MainCatID 
        rSubCategories.DataBind();
    }
    }
