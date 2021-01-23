    static void Main()
    {
        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString);
        builder.Password = "YourNewPassword";
        string newConnectionString = builder.ConnectionString;
    }
