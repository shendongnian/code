        string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\data.accdb;Persist Security Info=False;"; //This will be different for differing connection methods (you can find more on [ConnectionStrings.com][1]
        OleDbConnection conn = new OleDbConnection(connString);
        DataSet mainData = new DataSet();
        OleDbCommand accessCommand = new OleDbCommand("SELECT * FROM YOUR_TABLE_HERE", conn);
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter(accessCommand); //create the SQL command
        conn.Open();
        dataAdapter.Fill(mainData, "YOUR_TABLE_HERE"); //fill the dataset with the data from our SQL
        DataTable dta = mainData.Tables[0];
        DataTable schema = conn.GetSchema();
        schema.Tables["YOUR_TABLE_HERE"].Columns["YOUR_COLUMN_HERE"].AllowDBNull; //gets or sets if the column allows nulls
        conn.close();
