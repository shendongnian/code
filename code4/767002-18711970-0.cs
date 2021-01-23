     try
                 {
     
                     if (e.Row.RowType == DataControlRowType.Header)
                     {
                         DropDownList ddl = (DropDownList)e.Row.FindControl("ddlSorting");
                         SqlDataAdapter da = new SqlDataAdapter("SELECT ID,EmployeeName FROM Employee WHERE Inactive=0", con);
                         DataSet ds = new DataSet();
                         da.Fill(ds);
                         ddl.DataSource = ds.Tables[0];
                         ddl.DataTextField = "EmployeeName";
                         ddl.DataValueField = "ID";
                         ddl.DataBind();
                     }
                 }
                 catch (Exception ex)
                 {
                                 }
