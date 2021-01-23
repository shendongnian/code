    public DataTable Login(String Username, String Password)
    {
        try
        {
            SqlCommand cmd = new SqlCommand("Select * from tbl_Staff where Username=@Username and Password=@Password", conn);
            cmd.Parameters.AddWithValue("@Username", Username);
            cmd.Parameters.AddWithValue("@Password", Password);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
