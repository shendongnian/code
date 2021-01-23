    foreach (var cellValues in lines.Skip(
    {
        var cellArray = cellValues
            .Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
        //if (cellArray.Length == dataGridView1.Columns.Count)
            dataGridView1.Rows.Add(cellArray);
    }
