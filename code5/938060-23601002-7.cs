    foreach (var cellValues in lines.Skip(1))
    {
        var cellArray = cellValues.Split(new[] { ',' });
        if (cellArray.Length == dataGridView1.Columns.Count)
        {
            if (String.IsNullOrEmpty(cellArray[dataGridView1.Columns.Count]))
                cellArray[dataGridView1.Columns.Count] = "1";
            dataGridView1.Rows.Add(cellArray);
        }
    }
