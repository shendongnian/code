    internal static void StoreEntitiesToDatabase<T>(this IEnumerable<T> elements, SqlConnection connection,
        string tablename)
    {
        var sbc = new SqlBulkCopy(connection);
        {
            var table = new DataTable();
            Type listType = typeof (T);
            foreach (PropertyInfo propertyInfo in listType.GetProperties())
            {
                table.Columns.Add(propertyInfo.Name, propertyInfo.PropertyType);
                sbc.ColumnMappings.Add(propertyInfo.Name, propertyInfo.Name);
            }
            foreach (T value in elements)
            {
                DataRow dr = table.NewRow();
                foreach (PropertyInfo propertyInfo in listType.GetProperties())
                {
                    dr[propertyInfo.Name] = propertyInfo.GetValue(value, null);
                }
                table.Rows.Add(dr);
            }
            string sqlsc = "CREATE TABLE " + tablename + "(";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                sqlsc += "[" + table.Columns[i].ColumnName + "] ";
                int maxlen = table.Columns[i].MaxLength;
                if (maxlen == -1) maxlen = 255;
                if (table.Columns[i].DataType.ToString().Contains("System.Int32"))
                    sqlsc += " int ";
                else if (table.Columns[i].DataType.ToString().Contains("System.Int64"))
                    sqlsc += " bigint ";
                else if (table.Columns[i].DataType.ToString().Contains("System.DateTime"))
                    sqlsc += " datetime ";
                else if (table.Columns[i].DataType.ToString().Contains("System.String"))
                    sqlsc += " nvarchar(" + maxlen + ") ";
                else if (table.Columns[i].DataType.ToString().Contains("System.Double"))
                    sqlsc += " float ";
                else if (table.Columns[i].DataType.ToString().Contains("System.Decimal"))
                    sqlsc += " money ";
                else
                    throw new Exception("no mapping for " + table.Columns[i].DataType);
                if (table.Columns[i].AutoIncrement)
                    sqlsc += " IDENTITY(" + table.Columns[i].AutoIncrementSeed.ToString() + "," +
                                table.Columns[i].AutoIncrementStep.ToString() + ") ";
                if (!table.Columns[i].AllowDBNull)
                    sqlsc += " NOT NULL ";
                sqlsc += ",";
            }
            sqlsc = sqlsc.Substring(0, sqlsc.Length - 1) + ")";
            SqlCommand cmd = new SqlCommand(sqlsc, connection);
            cmd.ExecuteNonQuery();
            sbc.DestinationTableName = tablename;
            sbc.WriteToServer(table);
        }
    }
