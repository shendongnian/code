    var lines = File.ReadAllLines("input.txt");
    if (lines.Count() > 0)
    {
        foreach (var columnName in lines.FirstOrDefault()
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
        {
            dataGridView1.Columns.Add(columnName, columnName);
        }
        foreach (var cellValues in lines.Skip(1))
        {
            var cellArray = cellValues
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (cellArray.Length == dataGridView1.Columns.Count)
                dataGridView1.Rows.Add(cellArray);
        }
    }
