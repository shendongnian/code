    private Date GetDate(SqlConnection connection)
    {
        using (var command = connection.CreateCommand())
        {
            return ExecuteSP();
        }
    }
