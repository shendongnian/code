    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            yourSaveRoutine();
            dataGridView1.Rows.Add();
        }
    }
