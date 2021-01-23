    protected void grdInnerGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        //Accessing GridView from Sender object
        GridView childGrid = (GridView)sender;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Retreiving the GridView DataKey Value
            string cID = childGrid.DataKeys[e.Row.RowIndex].Value.ToString();
           
        }
    }
