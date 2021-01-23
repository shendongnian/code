    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ConnectionString);
    SqlCommand cmd = new SqlCommand();
    string s = "select id,name from tbl where id=@id";
    con.Open();
    cmd.Connection = con;
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = s;
    cmd.Parameters.AddWithValue("@id", 1);  // You set the param here
    cmd= new SqlCommand();  // You just effectively erased the previous 4 lines of code with this line.
    cmd.CommandType = CommandType.StoredProcedure;
    cmd.CommandText = "SroredProc";
    cmd.Parameters.AddWithValue("@Qry", s);
    DataTable dt = new DataTable();
    SqlDataAdapter da = new SqlDataAdapter(cmd);
    da.Fill(dt);
