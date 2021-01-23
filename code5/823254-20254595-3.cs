    if (!File.Exists(sdfPath))
    {
        using (var engine = new SqlCeEngine(dataSource))
        {
            engine.CreateDatabase();
        }
    }
    
    using (var connection = new SqlCeConnection(dataSource))
    {
        connection.Open();
        using (var command = new SqlCeCommand())
        {
            command.Connection = connection;
            command.CommandText ="IF NOT EXISTS( SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Platydudes') " 
                               + "CREATE TABLE Platydudes (Id int NOT NULL, BillSize smallint NOT NULL, Description nvarchar(255) )";
            command.ExecuteNonQuery();
        }
    }
