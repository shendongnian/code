    void RowDataBound(object sender, GridViewRowEventArgs e)
    {
     if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if(((Label)e.Row.FindControl("Status")).Text == "Active")
    {
      //disable
    }
    else
    {
    //enable
    }
    }
    }
