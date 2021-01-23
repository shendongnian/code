    private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv.CurrentCell != null)
            {
                text1.Text = ((DataGridView)sender).CurrentCell.Value.SafeToString();
            }
        }
