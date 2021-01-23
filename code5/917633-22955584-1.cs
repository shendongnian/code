    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            Form37 f = caller_form;
            f.a = 1;
            f.v = dataGridView1.SelectedCells[0].Value.ToString();
            f.Show();
            this.Close();
        }
    }
