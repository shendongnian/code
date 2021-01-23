    public static AddCustomer(DataTable customer)
    {
          try
          {
            DbCommand dbcomm = CDDAC.GetStoredProcCommand("name your stored procedure");
            CDDAC.AdInParameter(dbcomm, "@Param", SqlDbType.Structured, customer); //@param is an input parameter from your storedprocedure
            CDDAC.ExecuteNonQuery(dbcomm);
          }
          catch (Exception ex)
          {
            throw;
          }
        }
