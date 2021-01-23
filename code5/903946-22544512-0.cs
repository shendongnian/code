        try
            {
                string connectionString = @"Driver={Microsoft Excel Driver (*.xls, *.xlsx, *.xlsm, *.xlsb)};DBQ=C:\Temp\temp.xlsx;";
                System.Data.Odbc.OdbcConnection connection;
                System.Data.DataTable dataTable = new System.Data.DataTable("excelImport");
                System.Data.Odbc.OdbcDataAdapter dataAdapter;
                string m_selectSQL = "SELECT * FROM [Sheet1$]";
                connection = new System.Data.Odbc.OdbcConnection(connectionString);
                dataAdapter = new System.Data.Odbc.OdbcDataAdapter(m_selectSQL, connection);
                dataAdapter.Fill(dataTable);
            }
            catch (Exception e)
            {
 
            }
