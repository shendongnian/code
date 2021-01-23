    private System.Data.DataSet MyDataSet()
    {
         using (SqlConnection connection = new SqlConnection(strCon))
            {
                //Create a SqlDataAdapter 
                SqlDataAdapter adapter = new SqlDataAdapter();
                
                // Open the connection.
                connection.Open();
                SqlCommand command = new SqlCommand(sql_string, connection);
                command.CommandType = CommandType.Text;
                // Set the SqlDataAdapter's SelectCommand.
                adapter.SelectCommand = command;
                // Fill the DataSet.
                System.Data.DataSet dataSet = new System.Data.DataSet();
                adapter.Fill(dataSet);
                // Close the connection.
                connection.Close();
                return dataSet;
           }
         return default(System.Data.DataSet);
    }
