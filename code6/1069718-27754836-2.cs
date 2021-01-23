    protected void gvShow_RowDataBound(object sender, GridViewRowEventArgs e)
    {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              LinkButton lnkEdit= e.Row.FindControl("lnkEdit") as LinkButton;
              if(//your condition)
              {
                 lnkEdit.Enable=true\false;
              }
          }
    }
