    if(!Page.IsPostBack)
    {
    	using (SqlConnection conn = new SqlConnection(connection.getConnection()))
    	{
    		string sqlGetClass = "select pk_classID,brachName+'-'+classYear as 
                                             classInfo from tbl_studentClass";
    		SqlCommand cmdGetClass = new SqlCommand(sqlGetClass, conn);
    		conn.Open();
    		SqlDataAdapter da = new SqlDataAdapter(cmdGetClass);
    		DataSet ds = new DataSet();
    		da.Fill(ds);
    		ddlClass.DataSource = ds;
    		ddlClass.DataTextField = "classInfo";
    		ddlClass.DataValueField = "pk_classID";
    		ddlClass.DataBind();
    		ddlClass.Items.Insert(0, new ListItem("--SELECT--", ""));
    		conn.Close();
    	}
    }
