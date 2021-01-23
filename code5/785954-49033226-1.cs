    System.Data.DataSet myDataSet = new System.Data.DataSet();
    
    using (System.Data.SqlClient.SqlDataAdapter dbAdapter = new System.Data.SqlClient.SqlDataAdapter(dbCommand))
    {
        dbAdapter.TableMappings.Add("Table", "Cars");
        dbAdapter.TableMappings.Add("Table1", "Trucks");
            //...
    
        dbAdapter.Fill(myDataSet);
    }
