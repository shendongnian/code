    private static SqlTransaction transaction;
    private static SqlConnection conn;
    public static void BeginTransaction()
        {
            try
            {
                transaction = conn.BeginTransaction();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
