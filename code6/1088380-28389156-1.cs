    [WebMethod]
    public static string Auth() {
        String strConnString = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        string str = null;
        SqlCommand com;
        string query = String.Format("select COUNT(TeacherID) from USERS where User= '{0}' and Password='{1}'",  HttpContext.Current.Request.QueryString["username"],  HttpContext.Current.Request.QueryString["password"]);
        object obj = null;
        SqlConnection con = new SqlConnection(strConnString);
        con.Open();
        com = new SqlCommand(query, con);
        obj = com.ExecuteScalar();
        con.Close();
        Page.Response.Write(obj);
    }
