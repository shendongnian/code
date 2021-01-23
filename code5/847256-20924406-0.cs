    protected void grvEmp_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState & DataControlRowState.Edit) > 0)
        {
            SqlConnection cn = new System.Data.SqlClient.SqlConnection("Data Source=CHANGEME1;Initial Catalog=Reflection;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("select salary from employee", cn);
            DataSet ds = new DataSet();
            DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList1");        //null-unable to capture the control 
            da.Fill(ds);
            cn.Close();
            ddl.DataSource = ds;
            ddl.DataTextField = "salary";
            ddl.DataValueField = "salary";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
