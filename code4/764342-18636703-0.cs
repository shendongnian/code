    public double[] SumAllColumns(IDbConnection connection)
    {
        using (var cmd = connection.CreateCommand())
        {
            cmd.CommandText = "SELECT * FROM YourTable";
            using (var reader = cmd.ExecuteReader())
            {
                var values = new double[reader.FieldCount];
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        values[i] += reader.GetDouble(i);
                    }
                }
                return values;
            }
        }
    }
