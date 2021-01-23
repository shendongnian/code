    [WebMethod]
    public void UpdateDataBase(List<string> values)
    {
        SqlConnection conn = new SqlConnection("user id=******; password=*******; server=.\\SQLEXPRESS;database=************;");
        SqlCommand comm = new SqlCommand();
        comm.CommandText = "Insert into TestWeb(Test1,Test2,Test3) values(@p0,@p1,@p2)";
        comm.Parameters.AddWithValue("@p0", values[0]);
        comm.Parameters.AddWithValue("@p1", values[1]);
        comm.Parameters.AddWithValue("@p2", values[2]);
        comm.Connection = conn;
        comm.ExecuteNonQuery();
    }
