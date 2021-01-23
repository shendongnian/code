    protected void insertButton_Click(object sender, EventArgs e)
    {
        // This is the crux - 
    	GridViewRow row = (GridViewRow)((sender as Button).NamingContainer);
    	// ...
    	// then you can get your textboxes
    	// Since we know it's an insert
    	dt.Columns.Add("id");
    	dt.Columns.Add("name");
    	dt = (DataTable)Session["students"];
    	DataRow dr = dt.NewRow();
    	TextBox txtnewid = (TextBox) row.FindControl("txtNewId");
    	TextBox txtnewName =  (TextBox) row.FindControl("txtNewName");
    	dr["id"] =  txtnewid.Text;
    	dr["name"] = txtnewName.Text ;
    	dt.Rows.Add(dr);
    	Session["students"] = dt;
    	gv.DataSource = dt;
    	gv.DataBind();
    }
