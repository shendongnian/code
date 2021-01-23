    public DataTable  getAllUsers()
        {
            OracleConnection Connection = new OracleConnection(stringConnection);
            Connection.ConnectionString = stringConnection;
            Connection.Open();
            DataSet dataSet = new DataSet();
            OracleCommand cmd = new OracleCommand("semect * from Users");
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Connection;
            using (OracleDataAdapter dataAdapter = new OracleDataAdapter())
            {
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataSet);
            }
            return dataSet.Tables[0];
        }
