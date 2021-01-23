    void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
       {
          var idLinkBtn = e.Row.FindControl("idLinkBtn") as HyperLink;
          idLinkBtn.Visible = true;
       }
    }
