    using System.Configuration;
    ...
    string connectionString = string.Format(
        ConfigurationManager.ConnectionStrings["xxxx"].ConnectionString,
        serverIP,
        dbName);
