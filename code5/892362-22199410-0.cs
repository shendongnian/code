    protected void gv_useronline_Sorting(object sender, GridViewSortEventArgs e)
    {
        //Retrieve the table from the session object.
        DataTable dt = Session["useronlineTable"] as DataTable;
        if (dt != null)
        {
            //Sort the data
            DataView dv = dt.DefaultView;
            dv.Sort = e.SortExpression + " ASC"; // ASC or DESC 
            DataTable dtSorted = dv.ToTable();
            // Put the sorted table in session
            Session["useronlineTable"] = dtSorted;
            // Bind the GridView to the new 
            gv_useronline.DataSource = dt;
            gv_useronline.DataBind();
        }
    }
