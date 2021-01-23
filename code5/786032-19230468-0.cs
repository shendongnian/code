    using (SqlCeEngine engine = new SqlCeEngine())
    {
        engine.LocalConnectionString = yourConnectionString;
        engine.CreateDatabase();
    }
