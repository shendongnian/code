    switch (sender.ToString().Trim())
        {
            case "Hide selected":
                int count = dataGridView1.SelectedRows.Count;
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    row.Visible = false;
                }
                break;
            case "Unhide all":
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Visible = true;
                }
                break;
        }
