        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            for (int i = 0; i < read.FieldCount; i++)
            {
                Type dataType = read.GetFieldType(i);
                if (dataType == typeof(int))
                {
                    // Do for integers (INT, SMALLINT, BIGINT)
                }
                else if (dataType == typeof(double))
                {
                    // Do for doubles (DOUBLE, DECIMAL)
                }
                else if (dataType == typeof(string))
                {
                    // Do for Strings (VARCHAR, NVARCHAR)
                }
                else if (dataType == typeof(DateTime))
                {
                    // Do for DateTime (DATETIME)
                }
                else if (dataType == typeof(byte[]))
                {
                    // Do for Binary (BINARY, VARBINARY, NVARBINARY, IMAGE)
                }
            }
        }
