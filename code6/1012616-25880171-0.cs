    private static string GetXmlPlanForQuery(string queryText)
    {
        string result = null;
        using (var connection = new SqlConnection(connectionString))
        using (var command = new SqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            //Enable the statistics.
            command.CommandText = "SET STATISTICS XML ON";
            command.ExecuteNonQuery();
            //Run through the query, keeping the first row first column of the last result set.
            command.CommandText = queryText;
            using (var reader = command.ExecuteReader())
            {
                object lastValue = null;
                do
                {
                    if (reader.Read())
                    {
                        lastValue = reader.GetValue(0);
                    }
                } while (reader.NextResult());
                if (lastValue != null)
                {
                    result = lastValue as string;
                }
            }
        }
        return result;
    }
