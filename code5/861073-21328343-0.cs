    Parallel.ForEach(strings, str=> {
        object[] values = MyParser.Parse(str);
        lock(table) {
            table.Rows.Add(values);
        }
    });
