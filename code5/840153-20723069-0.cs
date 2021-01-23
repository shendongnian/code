        var con = new MySqlConnection(sql);
        con.Open();
        var command = new MySqlCommand("SELECT total FROM balance", con);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            balance.Text = reader[0].ToString();
        }
