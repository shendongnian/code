        SqlDataReader read = command.ExecuteReader();
        while (read.Read())
        {
            for (int i = 0; i < read.FieldCount; i++)
            {
                Type dataType = read.GetFieldType(i);
                if (dataType == typeof(int))
                {
                    // Do for integers
                }
                else if (dataType == typeof(string))
                {
                    // Do for Strings
                }
                else if (dataType == typeof(DateTime))
                {
                    // Do for DateTime
                }
                else if (dataType == typeof(byte[]))
                {
                    // Do for Binary
                }
            }
        }
