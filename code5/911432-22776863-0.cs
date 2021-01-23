    using (SqlConnection con= new SqlConnection (conString))
    {
        con.Open();
        foreach(var something in somelist)
        {
            using (SqlCommand cmd = new SqlCommand (insertSQLString, con))
            {
                cmd.Parameters.AddWithValue("@param1", something.SomeVal1);
                cmd.Parameters.AddWithValue("@param2", something.SomeVal2);
                cmd.ExecuteNonQuery();
            }
        }
    }
