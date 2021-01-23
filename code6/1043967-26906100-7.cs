    DataTable FileToDataTable1(string FilePath)
    {
        var dt = new DataTable();
        using (var st = new StreamReader(FilePath))
        {
            // first line procces
            if (st.Peek() >= 0)
            {
                var order = st.ReadLine().Split('|');
                dt.Columns.AddRange(order.Select(i => new DataColumn(i)).ToArray());
            }
            while (st.Peek() >= 0)
                dt.Rows.Add(st.ReadLine().Split('|'));
        }
        return dt;
    }
