            try
            {
                MySqlDataReader reader = null;
                string selectCmd = "SELECT * FROM  TabelaUtilizatori";
                MySqlCommand command = new MySqlCommand(selectCmd, _dbConnect.getConnection());
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string ColumnName = (string)reader["ColumnName"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
