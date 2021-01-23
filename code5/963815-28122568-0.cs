     MySqlConnection con = new MySqlConnection(connection);
            MySqlCommand command = con.CreateCommand();
            command.CommandText="insert into stactoverflowtable (id,name) values('1','adil')";//suppose table name is stackoverflowtalbe
            try
            {
                con.Open();
                command.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.Message;
                
            }
