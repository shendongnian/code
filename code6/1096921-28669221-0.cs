    if(dataGridView3.SelectedRows != null && dataGridView3.SelectedRows.Count > 0)
    {
        foreach (DataGridViewRow dgvr in dataGridView3.SelectedRows)
        {
            int tempVal = 0;
            if(dgvr.Cells["Cust_Number"].Value != null && int.TryParse(dgvr.Cells["Cust_Number"].Value.ToString(), out tempVal))
            {
                capStore.Add(tempVal);
            }
        }
    }
