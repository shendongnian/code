    protected void srchgrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           if(e.Row.RowType == DataControlRowType.DataRow) //to access data rows only (not to deal with HeaderRow and FooterRow
           {
               Label View = e.Row.FindControl("View_label_id") as Label;
               if(View != null)
               {
                  LinkButton btnView = e.Row.FindControl("btnView") as LinkButton;
                  if(btnView != null && View.Text.Trim() == "false")
                  {
                     btnView.Enabled = false;
                  }
               }
    
               Label Edit = e.Row.FindControl("Edit_label_id") as Label;
               if(View != null)
               {
                  LinkButton btnEdit = e.Row.FindControl("btnEdit") as LinkButton;
                  if(btnEdit != null && Edit.Text.Trim() == "false")
                  {
                     btnEdit.Enabled = false;
                  }
               }
           }
        }
