     private void ImporttoSQL(string sPath)
    {
        string sSourceConstr1 = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\AgentList.xls; Extended Properties=""Excel 8.0;HDR=YES;""", sPath);
        string sSourceConstr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", sPath);
        //   string sSource = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sPath + ";Extended Properties=Excel 8.0", sPath);
        // string sDestConstr = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        OleDbConnection sSourceConnection = new OleDbConnection(sSourceConstr);
        using (sSourceConnection)
        {
            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultSQLConnectionString"].ConnectionString);
            string sql = "Select [Merchant_Name],[Store_Name],[Store_Address],[City] FROM [Sheet1$]";
            OleDbCommand command = new OleDbCommand(sql, sSourceConnection);
            sSourceConnection.Open();
            conn.Open();
            using (OleDbDataReader dr = command.ExecuteReader())
            {
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
                {
                    bulkCopy.DestinationTableName = "MerchantTempDetail";
                    bulkCopy.ColumnMappings.Add("Merchant_Name", "Merchant_Name");
                    bulkCopy.ColumnMappings.Add("Store_Name", "Store_Name");
                    bulkCopy.ColumnMappings.Add("Store_Address", "Store_Address");
                    bulkCopy.ColumnMappings.Add("City", "City");
                     bulkCopy.WriteToServer(dr);
                }
            }
        }
    }
