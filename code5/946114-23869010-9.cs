    public async Task GetSomeDataAsync<T>(
        string sql, Func<IDataRecord, T> projector, ProducerConsumerHub<T> hub)
    {
        using (SqlConnection _conn = new SqlConnection(@"Data Source=..."))
        {
            using (SqlCommand _cmd = new SqlCommand(sql, _conn))
            {
                await _conn.OpenAsync();
                _cmd.CommandTimeout = 100000;
                using (var rdr = await _cmd.ExecuteReaderAsync())
                {
                    while (await rdr.ReadAsync())
                        await hub.ProduceAsync(projector(rdr));
                }
            }
        }
    }
