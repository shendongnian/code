    public enum DBConnectionStatus
        {
            CONNECTION_ERROR,
            AUTHENTICATION_ERROR,
            INVALID_DATABASE,
            UNKNOWN_ERROR,
            OK,
        };
      public static DBConnectionStatus ValidateConnection(string ConnectionString)
        {
            DBConnectionStatus result = DBConnectionStatus.UNKNOWN_ERROR;
            DataContext DB = new DataContext(ConnectionString);
            try
            {
                DB.Connection.Open();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case -1:
                    case 2: //Cant reach data source (not accessable or offline)
                        result = DBConnectionStatus.CONNECTION_ERROR;
                        break;
                    case 4060:
                        result = DBConnectionStatus.INVALID_DATABASE;
                        break;
                    case 18452:
                    case 18456: //Invalid Authentication
                        result = DBConnectionStatus.AUTHENTICATION_ERROR;
                        break;
                    default: //All other errors
                        result = DBConnectionStatus.UNKNOWN_ERROR;
                        break;
                }
            }
            finally
            {
                if (DB.Connection.State == ConnectionState.Open)
                {
                    DB.Connection.Close();
                }
            }
            return result;
        }
