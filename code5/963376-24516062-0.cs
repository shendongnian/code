    public void RefreshCollection(WqlConnectionManager connection, string collectionID)
    {
       IResultObject collection = connection.GetInstance(string.Format("SMS_Collection.CollectionID='{0}'", collectionID));
       collection.ExecuteMethod("RequestRefresh", null);
    }
