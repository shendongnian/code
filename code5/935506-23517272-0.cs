    string str = Request.QueryString["sub"];
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cozmotestConnectionString"].ConnectionString);
    SqlDataAdapter da = new SqlDataAdapter(
            "select * from entry_table Where sub='"+str+"'",con)
    //Your remaining parts will come here
