    if (GrdView.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow ro in GrdView.SelectedRows)
                    {
                        try
                        {
                            GrdView.Rows.RemoveAt(GrdView.SelectedRows[0].Index);
                        }
                        catch (Exception ex)
                        {
                            KryptonMessageBox.Show("Not Allowed...");
                        }
                    }
                }
