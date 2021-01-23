    protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.Header)
      {
          //e.Row.Cells[0].Text = "test";
                    
          LinkButton lnk1 = e.Row.Cells[0].Controls[0] as LinkButton;
          lnk1.Text = "test";
      }
    }
