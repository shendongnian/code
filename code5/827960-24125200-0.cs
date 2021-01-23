    DataTable GetTable(string commandText)
    {
        DataTable DataTable = null;
        DataTable TempDataTable = null;
        try
        {
            TempDataTable = new DataTable();
            TempDataTable.Locale = CultureInfo.InvariantCulture;
    
            using (ReliableSqlConnection ReliableSqlConnection = new ReliableSqlConnection(ConnectionString))
            {
                ReliableSqlConnection.Open();
                using (SqlCommand SqlCommand = new SqlCommand(commandText, ReliableSqlConnection.Current))
                {
                    SqlCommand.CommandType = CommandType.Text;
                    TempDataTable.Load(SqlCommand.ExecuteReaderWithRetry());
                }
            }
            DataTable = TempDataTable;
            TempDataTable = null;
        }
        finally
        {
            if (TempDataTable != null)
            {
                TempDataTable.Dispose();
            }
        }
        return DataTable;
    }
