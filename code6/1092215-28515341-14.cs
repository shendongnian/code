    private static SqlTransaction transaction;
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
