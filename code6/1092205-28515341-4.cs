    public static void CommitTransaction()
        {
            try
            {
                transaction.Commit();
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
