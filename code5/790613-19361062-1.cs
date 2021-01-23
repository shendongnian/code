    protected void gvAlbumImages_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               DataRow aRow = ((DataRowView)e.Row.DataItem).Row; 
               //This is the Row from your Datasource (which is a datatable)
               
              Image img =  (Image)e.Row[e.Row.RowIndex].FindControl("imgControl");
                  //get the  Image object at the row you are binding to.
                 //now simply set the source from the value in the DataRow
               img.ImageUrl = string.format("~/ImageHandler.ashx?ImageID={0}",aRow.Field<int>("ImageID")
                
             }
        }
