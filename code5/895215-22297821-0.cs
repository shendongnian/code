    SQLiteConnectionStringBuilder conString = new SQLiteConnectionStringBuilder();
    conString.DataSource = databaseFileName;
    conString.DefaultTimeout = 5000;
    conString.FailIfMissing = false;
    conString.ReadOnly = false; 
  
