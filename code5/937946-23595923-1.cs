    int id = 1;
    SqlConnection con = new 
    SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    string s = string.format("select id,name from tbl where id={0}",id);
    cmd.Connection = con;
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "SroredProc";
    cmd.Parameters.AddWithValue("@Qry", s);
    DataTable dt = new DataTable();
    con.Open();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
