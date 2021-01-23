    using(SqlConnection conn = new SqlConnection(connString))
    using(SqlCommand cmd = conn.CreateCommand())
    {
        cmd.CommandText = "select count(*) from [Table] where [User Name] = @UserName";
        com.Parameters.Add("@UserName", SqlDbType.NChar, 20).Value = TextBoxUN.Text;
        conn.Open();
        int temp = Convert.ToInt32(com.ExecuteScalar()); 
    }
