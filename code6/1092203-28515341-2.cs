    public static void RollbackTransaction()
        {
            try
            {
                transaction.Rollback();
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
