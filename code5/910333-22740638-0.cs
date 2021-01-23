    protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int Prod_Id = Convert.ToInt32(e.CommandArgument);        
    
            DataTable dtToGrid = (DataTable)Session["dtToGrid"];
            
            DataRow rowToBeDeleted = dtToGrid.Rows.Where(r=>r["Prod_Id"] == Prod_Id.ToString());
    
            if (rowToBeDeleted != null)
            {
              dtToGrid.Rows.Remove(rowToBeDeleted);
    
              grd.DataSource = dtToGrid;
              grd.DataBind();
    
              // do your summation logic.
            }
        }
    }
