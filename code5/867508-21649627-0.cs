    if (statement == null || !statement.IsPrepared)
    {
      if (CommandType == CommandType.StoredProcedure)
    	statement = new StoredProcedure(this, sql);
      else
    	statement = new PreparableStatement(this, sql);
    }
    
    // stored procs are the only statement type that need do anything during resolve
    statement.Resolve(false); // the problem occurs here
