    private DB1 db = null; 
    private DB1 Db
    {
      get
      {
        if (db == null)
        {
          db = specific context type according to user choice;
        }
        return db;
      }
    }
