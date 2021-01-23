    protected void gv_RowDataBound(object sender, GridViewEditEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
          {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                  DropDownList DStatusEdit= (DropDownList)e.Row.FindControl("DStatusEdit");
                  DataTable dt = con.GetData("select distinct status from directory");
                  DStatusEdit.DataSource = dt;
                  DStatusEdit.DataTextField = "status";
                  DStatusEdit.DataValueField = "status";
                  DStatusEdit.DataBind();
                  DataRowView dr = e.Row.DataItem as DataRowView;
                  DStatusEdit.SelectedValue = dr["columnname"].ToString();
                }
           }
        }
     }
    
        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
          gv.EditIndex = e.NewEditIndex;
          gridviewBind();// your gridview binding function
        }
