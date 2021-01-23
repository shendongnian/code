    private void btnSelectAll_Click(object sender, EventArgs e)
            {
                lstSelectRows.BeginUpdate();
                lstSelectRows.SelectionMode = SelectionMode.MultiSimple;
                for (int i = 0; i < lstSelectRows.Items.Count; i++)
                {
                    lstSelectRows.SetSelected(i, true);
                }
                lstSelectRows.EndUpdate();
            }
    private void btnSelectNone_Click(object sender, EventArgs e)
            {
                lstSelectRows.BeginUpdate();
                this.lstSelectRows.SelectedIndex = -1;
                lstSelectRows.EndUpdate();
            }
