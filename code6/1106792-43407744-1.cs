     public async List<Student> allStudentsAsync()
            {
             result = new List<Student>();
            while (query.HasMoreResults)
            {
                var response = await query.ExecuteNextAsync<T>();
                             result.AddRange(response);
            }
