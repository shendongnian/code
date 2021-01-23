        public DataTable Select(string query = "")
        {
            if (query == "")
            {
                query = "SELECT * FROM motorconfig";
            }
            DataTable dt = new DataTable();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);
                //close Data Reader
                dataReader.Close();
                //close Connection
                this.CloseConnection();
                //return list to be displayed
                return dt;
            }
            else
            {
                return dt;
            }
        }
