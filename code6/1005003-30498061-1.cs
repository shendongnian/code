        public void WriteConfig(DataTable dt, string DataTableSqlSelect)
        {
            //Typically "SELECT * FROM motorparameter"
            string query = DataTableSqlSelect;
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand mySqlCmd = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(mySqlCmd);
                MySqlCommandBuilder myCB = new MySqlCommandBuilder(adapter);
                adapter.UpdateCommand = myCB.GetUpdateCommand();
                adapter.Update(dt);
                //close Connection
                this.CloseConnection();
                //return list to be displayed
            }
            else
            {
            }
        }
