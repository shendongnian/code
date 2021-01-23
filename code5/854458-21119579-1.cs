    for (int x = 0; x < dataGridView1.Rows.Count - 1; x++)
    {
        string line = string.Join("|", dataGridView1.Rows[x].Cells.Select(c => c.Value);
        sw.WriteLine(line);
    }
