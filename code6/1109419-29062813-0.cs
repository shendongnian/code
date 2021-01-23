            try
            {
                MySqlDataReader reader = null;
                string selectCmd = "SELECT * FROM  TabelaUtilizatori";
                MySqlCommand command = new MySqlCommand(selectCmd, _dbConnect.getConnection());
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string TableName = (string)reader["TableName"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
