    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
        var registrations = ((YourType)e.Row.DataItem).Registrations;
        //do something 
      }
    }
