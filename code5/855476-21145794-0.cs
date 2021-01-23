        static IEnumerable<string> GetSomeData()
        {
            using (var connection = new SqlConnection("..."))
            {
                connection.Open();
                using (var command = new SqlCommand("select name from some_table", connection))
                using (var reader = command.ExecuteReader())
                {
                    yield return reader.GetString(0);
                }
            }
        }
