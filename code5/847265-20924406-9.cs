    using (SqlConnection cn = new System.Data.SqlClient.SqlConnection("Data Source=CHANGEME1;Initial Catalog=Reflection;Integrated Security=True"))
    {            
        cn.Open();
        using (SqlDataAdapter da = new SqlDataAdapter("select salary from employee", cn))
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddl.DataSource =dt;
            ddl.DataTextField = "salary";
            ddl.DataValueField = "salary";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    } 
