    public SqlConnection openConnection (string connString) {
      SqlConnection conn = null;
    
      try {
        conn = new SqlConnection(connString));
    
        return conn;
      }
      catch (Exception e) { // <- Probably, you should catch more specific exception, e.g. DataException
        // This "if" (that's a part of typical using emulation scheme) is redundant
        // you may safely remove it unless there's no addition code in the "try"
        // see Todd Bowles comments
        if (!Object.ReferenceEquals(null, conn))
          conn.Dispose();
    
        // Do not forget to pass the reason (intitial exception e)
        // when throwing your own one
        throw new OrdersDBInternalFaultException(e);    
      }
    }
