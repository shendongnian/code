    private void belowstock()
    {
        dataGridView1.Rows.Cast<DataGridViewRow>().Where(w => (int)w.Cells[5].Value < 10).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Red);
        dataGridView1.Rows.Cast<DataGridViewRow>().Where(w => (int)w.Cells[5].Value > 10).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.White);
    }
