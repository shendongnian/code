    SqlCommand com = new SqlCommand("select * from Table_1", con);
    SqlDataReader reader = com.ExecuteReader();
    
    string test = "";
    while (reader.Read())
    {
        test = reader["col"].ToString();
    
        SqlCommand com1 = new SqlCommand("insert into Table_2 values(@ID,@col)", con);
        com1.Parameters.AddWithValue("@ID", TextBox1.Text);
        com1.Parameters.AddWithValue("@col", test);
        com1.ExecuteNonQuery();
    }
