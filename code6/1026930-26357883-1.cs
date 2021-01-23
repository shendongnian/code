    public List<List<string>> ExecuteScalarEx()
    {
        if (_conn.Trace)
        {
            Debug.WriteLine("Executing Query: " + this);
        }
        List<List<string>> stringList = new List<List<string>>();
        var stmt = Prepare();
        while (SQLite3.Step(stmt) == SQLite3.Result.Row)
        {
            int columnCount = SQLite3.ColumnCount(stmt);
            List<string> row = new List<string>();
            for (int i = 0; i < columnCount; i++)
            {
                var colType = SQLite3.ColumnType(stmt, i);
                string val = (ReadColEx(stmt, i, colType) ?? "").ToString();
                row.Add(val);
            }
            stringList.Add(row);
        }
        return stringList;
    }
