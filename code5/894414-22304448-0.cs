    protected void GetItems(object sender, GridViewRowEventArgs e)
    {
		if (e.Row.RowType != DataControlRowType.DataRow)
        {
            return;
        }
        // Get the ID from the GridView
        var dataRowView = (DataRowView) e.Row.DataItem;
        var id = dataRowView["ID"].ToString();
        // Bind the supporting documents to the ListView control
        var listView = (ListView) e.Row.FindControl("listOfItems");
        listView.DataSource = /* Call to database to return a DataSet of items */;
        listView.DataBind();
    }
