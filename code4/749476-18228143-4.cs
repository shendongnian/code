    SqlConnection conn = null;
    
    try {
      SqlConnection conn = new SqlConnection(connString);
    
      // Some Code
      ...
    }
    finally {
      if (!Object.ReferenceEquals(null, conn))
        conn.Dispose();
    }
