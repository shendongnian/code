    {
        DataGridViewRow row = (DataGridViewRow)yourdatagrid.Rows[0].Clone();
        // then for each of the values use a loop like below.
        int cc = yourdatagrid.Columns.Count;
        DataGridViewRow row = (DataGridViewRow)yourdatagrid.Rows[0].Clone();
        for (int i2 = 0; i < cc; i2++)
        {
            row.Cells[i].Value = yourdatagrid.Rows[0].Cells[i].Value;
        }
        yourdatagrid.Rows.Add(row);
        i++;
        }
    }
