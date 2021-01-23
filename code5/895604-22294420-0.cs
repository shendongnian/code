    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           GridView.Columns[0].HeaderText = "New Header text for First Column";
        }
    }
