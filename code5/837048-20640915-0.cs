    public StoreInfo GetStoreByID(int _storeID)
    {
        using (BlueBerry_MTGEntities mDb = new BlueBerry_MTGEntities())
        {
            mDb.Database.Connection.Open();
    
            // Bla bla stuff to return the proper StoreInfo Object.
        }
    }
