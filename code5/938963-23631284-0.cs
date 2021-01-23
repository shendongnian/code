    protected void gvEmployee_RowDataBound(object sender, GridViewRowEventArgs e)
    {      
        if(!(sender is GridView))
            return;
    
        GridView gridView = (GridView) sender;
        var colCount = gridView.Columns.Count;
    
       //Your code
    }
