    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow != null)
        {
            int rowindex = dataGridView1.CurrentRow.Index;
            if (rowindex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[rowindex];
                if (row.Cells["X"].Value != null) txtpaX.Text = row.Cells["X"].Value.ToString();
                if (row.Cells["Y"].Value != null) txtpaY.Text = row.Cells["Y"].Value.ToString();
                if (row.Cells["item"].Value != null) lblinfo.Text = row.Cells["item"].Value.ToString();
                xposition = int.Parse(txtpaX.Text);
                yposition = int.Parse(txtpaY.Text);
                flag = 1;
            }
        }
    }
