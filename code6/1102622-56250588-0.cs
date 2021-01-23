    public async Task InsertInBulk(IList<string> userNames)
    {
        var sqls = GetSqlsInBatches(userNames);
        using (var connection = new SqlConnection(ConnectionString))
        {
            foreach (var sql in sqls)
            {
                await connection.ExecuteAsync(sql);
            }
        }
    }
    private IList<string> GetSqlsInBatches(IList<string> userNames)
    {
        var insertSql = "INSERT INTO [Users] (Name, LastUpdatedAt) VALUES ";
        var valuesSql = "('{0}', getdate())";
        var batchSize = 1000;
        var sqlsToExecute = new List<string>();
        var numberOfBatches = (int)Math.Ceiling((double)userNames.Count / batchSize);
        for (int i = 0; i < numberOfBatches; i++)
        {
            var userToInsert = userNames.Skip(i * batchSize).Take(batchSize);
            var valuesToInsert = userToInsert.Select(u => string.Format(valuesSql, u));
            sqlsToExecute.Add(insertSql + string.Join(',', valuesToInsert));
        }
        return sqlsToExecute;
    }
