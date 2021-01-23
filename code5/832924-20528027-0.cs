    bool shouldNotFilter = string.IsNullOrEmpty(driverNo.Text);
    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (shouldNotFilter)
        {
            row.Visible = true;
        }
        else
        {
            if (!string.Equals(row.Cells[1].Value.ToString(), driverNo.Text, StringComparison.OrdinalIgnoreCase))
            {
                row.Visible = false;
            }
        }
    }
