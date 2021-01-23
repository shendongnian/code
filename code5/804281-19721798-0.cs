    //ServiceStack's JSON and JSV Format
    SqliteDialect.Provider.StringSerializer = new JsvStringSerializer();       
    PostgreSqlDialect.Provider.StringSerializer = new JsonStringSerializer();
    //.NET's XML and JSON DataContract serializers
    SqlServerDialect.Provider.StringSerializer = new DataContractSerializer();
    MySqlDialect.Provider.StringSerializer = new JsonDataContractSerializer();
    //.NET XmlSerializer
    OracleDialect.Provider.StringSerializer = new XmlSerializableSerializer();
