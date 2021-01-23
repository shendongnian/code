    using (MySqlConnection c = new MySqlConnection(connString))
    {
        c.Open();
    
        var sql = "SELECT field_name FROM table_name";
        using (MySqlCommand cmd = new MySqlCommand(sql, c))
        {
            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
    
            comboBox.ValueMember = "field_name";
            comboBox.DisplayMember = "field_name";
            comboBox.DataSource = dt;
        }
    }
