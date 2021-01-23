    class XmlDataStoreFactory : IDataStoreFactory<XmlDocument>
    {
        IDataStore<XmlDocument> Create(XmlDocument document)
        {
            return new XmlDataStore(document);
        }
    }
    
    class SQLDataStoreFactory : IDataStoreFactory<SqlConnection>
    {
        IDataStore<SqlConnection> Create(SqlConnection connection)
        {
            return new SQLDataStore(connection);
        }
    }
