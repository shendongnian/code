    public bool SaveItem<T>(T item, ref int primaryKey) where T : ICommonInterface, new()
    {
        var dbConn = new SQLiteConnection(dbPath);
    
    
        T storedItem = dbConn.Find<T>(x => x.PrimaryKey == item.PrimaryKey);
    
        if (storedItem != null)
        {
            dbConn.Update(item);
            return true;
        }
        else if (storedItem == null)
        {
            dbConn.Insert(item);
            primaryKey = item.PrimaryKey;
            return true;
        }
        return false;
    }
