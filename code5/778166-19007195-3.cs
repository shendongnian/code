     query = "INSERT INTO MCDPhoneNumber (MCDID, PhoneNumber) VALUES(@maxid, @tel)";
     using(SqlConnection conn = new SqlConnection("Data Source=source; Initial Catalog=base; Integrated Security = true"))
     {
        SqlCommand newCommand = new SqlCommand(query, conn);
        conn.Open();
        newCommand.Parameters.AddWithValue("@maxid", maxid);
        newCommand.Parameters.AddWithValue("@tel", tel);
    
        int success= newCommand.ExecuteNonQuery();
        if (success != 1)
        {
             MessageBox.Show("It didn't insert shit:" + query);
        }
     }
