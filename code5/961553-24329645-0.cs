    using (MySqlConnection conn = new MySqlConnection(cs))
    {
        // No need to test if the connection is not open....
        conn.Open();
        .........
        // Not needed (at least from your code above
        // MySqlDataAdapter MyAdapter2 = new MySqlDataAdapter();
        // MyAdapter2.SelectCommand = myCommand2;
        ... calcs follow here
        // Attention here, if the query returns null (no input match) this line will throw
        oldpoints = (int)myCommand2.ExecuteScalar();
        
        .... other calcs here
        
        MySqlCommand cmdDataBase = new MySqlCommand(query, conn);
        cmdDataBase.Parameters.Add("@input", SqlDbType.Int).Value = Convert.ToInt32(textBox2.Text);
        cmdDataBase.Parameters.AddWithValue("@Points", new_points);
        cmdDataBase.Parameters.AddWithValue("@Rewards", new_rewards);
        cmdDataBase.Parameters.AddWithValue("@Transaction", textBox3.Text);
        cmdDataBase.Parameters.AddWithValue("@TransationDate", transaction_date);
        // Use ExecuteNonQuery for INSERT/UPDATE/DELETE and other DDL calla
        cmdDataBase.ExecuteNonQuery();
        // Not needed
        // MySqlDataReader myReader2;
        // myReader2 = cmdDataBase.ExecuteReader();
        // Not needed, the using block will close and dispose the connection
        if(conn.State == ConnectionState.Open)
            conn.Close();
    }
