    var sb = new StringBuilder();
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        foreach (DataGridViewCell cell in row.Cells)
        {
            sb.AppendLine(Convert.ToString(cell.Value));
        }
    }
    ResultsText.Text = sb.ToString();
