    public OleDbDataReader ExecuteReader(CommandBehavior behavior)
    {
     OleDbDataReader reader;
     IntPtr ptr;
     OleDbConnection.ExecutePermission.Demand();
     Bid.ScopeEnter(out ptr, "<oledb.OleDbCommand.ExecuteReader|API> %d#, behavior=%d{ds.CommandBehavior}\n", this.ObjectID, (int) behavior);
     try
     {
         this._executeQuery = true;
         reader = this.ExecuteReaderInternal(behavior, "ExecuteReader");
     }
     finally
     {
         Bid.ScopeLeave(ref ptr);
     }
     return reader;
    }
