        public void UpdateTable(DataTable table, int customerId)
        {
            using (MySqlConnection connect = new MySqlConnection(ConnString))
            {
                connect.Open();
                MySqlCommandBuilder commbuilder = new MySqlCommandBuilder(adapt);
                adapt.SelectCommand = new MySqlCommand("SELECT * FROM customers WHERE Id = "+customerId, connect); //or use parameters.addwithvalue
                adapt.Update(table);
            }
        }
