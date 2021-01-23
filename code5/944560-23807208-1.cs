    private void LoadList()
    {
        List<TagsTable> tagsList;
        using (IDbConnection connection =
            new SqlConnection(Properties.Settings.Default.DBConnectionString))
        {
            tagsList = connection.Query<TagsTable>(sqlStatement);
        }
    }
