    private static void OutputTable(string query, bool showHeader)
    {
        List<Log> result = new List<Log>();
        MySqlConnection conn = GetConn();
        MySqlCommand cmd = conn.CreateCommand();
        cmd.CommandText = query;
        MySqlDataReader reader = cmd.ExecuteReader();
        int columnCount = reader.FieldCount;
        List<List<string>> output = new List<List<string>>();
        if (showHeader)
        {
            List<string> values = new List<string>();
            for (int count = 0; count < columnCount; ++count)
            {
                values.Add(string.Format("{0}", reader.GetName(count)));
            }
            output.Add(values);
        }
        while (reader.Read())
        {
            List<string> values = new List<string>();
            for (int count = 0; count < columnCount; ++count)
            {
                values.Add(string.Format("{0}", reader[count]));
            }
            output.Add(values);
        }
        reader.Close();
        List<int> widths = new List<int>();
        for (int count = 0; count < columnCount; ++count)
        {
            widths.Add(0);
        }
        foreach (List<string> row in output)
        {
            for (int count = 0; count < columnCount; ++count)
            {
                widths[count] = Math.Max(widths[count], row[count].Length);
            }
        }
        //int totalWidth = widths.Sum() + (widths.Count * 1) * 3;
        //Console.SetWindowSize(Math.Max(Console.WindowWidth, totalWidth), Console.WindowHeight);
        foreach (List<string> row in output)
        {
            StringBuilder outputLine = new StringBuilder();
            for (int count = 0; count < columnCount; ++count)
            {
                if (count > 0)
                {
                    outputLine.Append(" ");
                }
                else
                {
                    outputLine.Append("| ");
                }
                string value = row[count];
                outputLine.Append(value.PadLeft(widths[count]));
                outputLine.Append(" |");
            }
            Console.WriteLine("{0}", outputLine.ToString());
        }
    }
