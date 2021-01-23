     public string GetMatchCode()
        {
            //this could be loaded from config file or other source
            string connectString = "Server=123.123.1.23;Database=blah_users;Uid=blah_data;Pwd=blahblah;sslmode=none;";
            string sql = "SELECT MAX(match_id) FROM `data_blah`";
            using (var connect = new MySqlConnection(connectString))
            using (var command = new MySqlCommand(sql, connect))
            {
                connect.Open();
                return command.ExecuteScalar().ToString();
            }
        }
