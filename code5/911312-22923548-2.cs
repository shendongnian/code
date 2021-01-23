    private void GetData()
    {
        try
        {
            conn = new SqlConnection(connstr);
            conn.Open();
            // Create a DataSet.
            data = new DataSet();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            string sqlStr = "SELECT [Project Customer UBF].* FROM [Project Customer UBF]; "; //WHERE [Project Customer UBF].[Project Id] = " +_projectID;                       
            // Add data from the Customers table to the DataSet.
            masterDataAdapter = new
                SqlDataAdapter(sqlStr, conn);
            masterDataAdapter.Fill(data, "Customers");
            // Add data from the Orders table to the DataSet.
            detailsDataAdapter = new
                SqlDataAdapter("SELECT [Project Customer Discount].* FROM [Project Customer Discount]", conn);
            detailsDataAdapter.Fill(data, "Discounts");
            detailsDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            GenerateCommands();
            CreateRelations();
            // Bind the master data connector to the Customers table.
            masterBindingSource.DataSource = data;
            masterBindingSource.DataMember = "Customers";
            masterBindingSource.Filter = "[Project Id] =" + _projectID;
            // Bind the details data connector to the master data connector, 
            // using the DataRelation name to filter the information in the  
            // details table based on the current row in the master table. 
            detailsBindingSource.DataSource = masterBindingSource;
            detailsBindingSource.DataMember = "CustDist";
            conn.Close();
        }
        catch (SqlException)
        {
            MessageBox.Show("To run this example, replace the value of the " +
                "connectionString variable with a connection string that is " +
                "valid for your system.");
        }
    }
