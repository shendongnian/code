    string sqlConnectString = "YourConnectionString";
    string sqlSelect = "SELECT name FROM server WHERE code= @CodeValue";
     
    SqlConnection sqlConnection = new SqlConnection(sqlConnectString);
    SqlCommand sqlCommand = new SqlCommand(sqlSelect, sqlConnection);
     
    sqlCommand.Parameters.Add("@CodeValue", System.Data.SqlDbType.Int);// Set SqlDbType based on your DB column Data-Type
    
     sqlCommand.Parameters["@CodeValue"].Value = TextBox1.Text;
     
    SqlDataAdapter sqlDa = new SqlDataAdapter(sqlCommand);
    DataTable sqlDt = new DataTable();
    sqlDa.Fill(sqlDt);
