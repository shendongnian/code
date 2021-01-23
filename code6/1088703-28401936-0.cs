    StreamWriter writer = new StreamWriter(valuePath);
    string line;
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        line = "";
        foreach (DataGridViewCell cell in row.Cells)
        {
            line += cell.Value.ToString();
        }
        writer.WriteLine(line);
    }
    writer.Close();
