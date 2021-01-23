    using (MySqlConnection c = new MySqlConnection(connString))
    {
        c.Open();
    
        var sql = "SELECT key_field, display_field FROM table_name";
        using (MySqlCommand cmd = new MySqlCommand(sql, c))
        {
            var dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
    
            comboBox.ValueMember = "key_field";
            comboBox.DisplayMember = "display_field";
            comboBox.DataSource = dt;
        }
    }
