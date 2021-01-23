    public DataTable GetYourData()
        {
            DataTable YourResultSet = new DataTable();
            OleDbConnection yourConnectionHandler = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=C:\Users\PC1\Documents\Visual FoxPro Projects\");
            // if including the full dbc (database container) reference, just tack that on
            //      OleDbConnection yourConnectionHandler = new OleDbConnection(
            //          "Provider=VFPOLEDB.1;Data Source=C:\\SomePath\\NameOfYour.dbc;" );
            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();
            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                string mySQL = "select * from CLIENTS";  // dbf table name
                OleDbCommand MyQuery = new OleDbCommand(mySQL, yourConnectionHandler);
                OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);
                DA.Fill(YourResultSet);
                yourConnectionHandler.Close();
            }
            return YourResultSet;
        }
