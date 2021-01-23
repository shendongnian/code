    protected void gvEntity_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           HiddenField Hf = (HiddenField) e.Row.FindControl("HiddenField1");
           if(Hf.Value=="Y")
               e.Row.Enabled = false;
          
        }
    
    }
