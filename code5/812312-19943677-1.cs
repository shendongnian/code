    void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
       if(e.Row.RowType == DataControlRowType.DataRow)
       {
          var idLinkBtn = e.Row.FindControl("idLinkBtn") as HyperLink;
          // The as operator will return null if the cast fails,
          // so check for null before you try to use the hyper link
          if(idLinkBtn != null)
          {
              idLinkBtn.Visible = true;
          }
       }
    }
