    private void CopyAll(DataGridView from, DataGridView to)
    {
        if (to.Columns.Count == 0)
        {
            foreach (DataGridViewColumn dgvc in from.Columns)
            {
                to.Columns.Add(dgvc.Name, dgvc.HeaderText);
            }
        }
        to.Rows.Clear();
        foreach(DataGridViewRow dgvr in from.Rows)
        {
            List<string> cells = new List<string>();
            foreach(DataGridViewCell dgvc in dgvr.Cells)
            {
                cells.Add(dgvc.Value.ToString());
            }
            to.Rows.Add(cells.ToArray());
        }
    }
