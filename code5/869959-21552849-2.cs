    if (GrdView.SelectedRows.Count > 0)
    {
        foreach (DataGridViewRow ro in GrdView.SelectedRows)
        {
            try
            {
                GrdView.Rows.Remove(ro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not Allowed...");
            }
        }
    }
