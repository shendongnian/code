    void RowDataBound(object sender, GridViewRowEventArgs e)
    {
     if(e.Row.RowType == DataControlRowType.DataRow)
        {
            if(e.Row.Cells[2].Text == "Active")
    {
      //disable
    }
    else
    {
    //enable
    }
    }
    }
