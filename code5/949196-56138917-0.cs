        public IEnumerable<T> GetAll<T>(string tableName) where T : class
        {
            var table = this.GetCloudTable(tableName);
            TableContinuationToken token = null;
            do
            {
                var q = new TableQuery<T>();
                var queryResult = Task.Run(() => table.ExecuteQuerySegmentedAsync(q, token)).GetAwaiter().GetResult();
                foreach (var item in queryResult.Results)
                {
                    yield return item;
                }
                token = queryResult.ContinuationToken;
            } while (token != null);
        }
