    public static void DumpTableToFile(SqlConnection connection, Dictionary<string, string> cArgs)
    {
        string query = "SELECT ";
        string z = "";
        if (cArgs.TryGetValue("top_count", out z))
        {
            query += string.Format("TOP {0} ", z);
        }
        query += string.Format("* FROM {0} (NOLOCK) ", cArgs["table"]);
        string lower_bound = "", upper_bound = "", column_name = "";
        if (cArgs.TryGetValue("lower_bound", out lower_bound) && cArgs.TryGetValue("column_name", out column_name))
        {
            query += string.Format("WHERE {0} >= {1} ", column_name, lower_bound);
            if (cArgs.TryGetValue("upper_bound", out upper_bound))
            {
                query += string.Format("AND {0} < {1} ", column_name, upper_bound);
            }
        }
        Console.WriteLine(query);
        Console.WriteLine("");
        using (var command = new SqlCommand(query, connection))
        using (var reader = command.ExecuteReader())
        using (var outFile = File.CreateText(cArgs["out_file"]))
        {
            string[] columnNames = GetColumnNames(reader).ToArray();
            int numFields = columnNames.Length;
            Console.WriteLine(string.Join(",", columnNames));
            Console.WriteLine("");
            if (reader.HasRows)
            {
                Type datetime_type = Type.GetType("System.DateTime");
                Type byte_arr_type = Type.GetType("System.Byte[]");
                string format = "yyyy-MM-dd HH:mm:ss.fff";
                int ii = 0;
                while (reader.Read())
                {
                    ii += 1;
                    string[] columnValues =
                        Enumerable.Range(0, numFields)
                            .Select(i => reader.GetValue(i).GetType()==datetime_type?((DateTime) reader.GetValue(i)).ToString(format):(reader.GetValue(i).GetType() == byte_arr_type? String.Concat(Array.ConvertAll((byte[]) reader.GetValue(i), x => x.ToString("X2"))) :reader.GetValue(i).ToString()))
                            ///.Select(field => string.Concat("\"", field.Replace("\"", "\"\""), "\""))
                            .Select(field => field.Replace("\t", " "))
                                    .ToArray();
                    outFile.WriteLine(string.Join("\t", columnValues));
                    if (ii % 100000 == 0)
                    {
                        Console.WriteLine("row {0}", ii);
                    }
                }
            }
        }
    }
    public static IEnumerable<string> GetColumnNames(IDataReader reader)
    {
        foreach (DataRow row in reader.GetSchemaTable().Rows)
        {
            yield return (string)row["ColumnName"];
        }
    }
