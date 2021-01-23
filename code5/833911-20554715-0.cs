    DateTime dateBase = DateTime.Parse(odDate);
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        DateTime dateRow = DateTime.Parse(row.Cells[0].Value.ToString());
        row.Visible = (dateRow >= dateBase);
    }
