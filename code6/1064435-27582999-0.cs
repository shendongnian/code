    private MySqlDataAdapter adapt;
    private DataSet someDataSet;
    someDataSet = new DataSet();
        public DataSet GetCustomerData(int customerId)
        {
            using(MySqlConnection connect = new MySqlConnection(ConnString))
            {
                connect.Open();
                MySqlCommand comm = new MySqlCommand("SELECT * FROM customers WHERE Id = @0", connect);
                someDataSet.Tables.Add("CustomersTable");
                comm.Parameters.AddWithValue("@0", customerId);
                adapt.SelectCommand = comm;
                adapt.Fill(someDataSet.Tables["CustomersTable"]);
            }
            
            return someDataSet;
       }
