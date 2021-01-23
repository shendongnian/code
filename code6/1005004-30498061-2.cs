        public DataTable Select(string query = "")
        {
            //Typical sql: "SELECT * FROM motorparameter"
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
                //return data table
                return dt;
            }
            else
            {
                return dt;
            }
        }
