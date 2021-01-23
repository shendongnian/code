    private void RemoveFileFromTable(object sender, GridViewDeleteEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
       {
          DropDownList ddl = e.Row.FindControl("DropDownList1") as DropDownList;
          if (ddl != null)
          {              
              if(ddl.SelectedValue == "someValue") doSomeThing();
          }
       }
     }
