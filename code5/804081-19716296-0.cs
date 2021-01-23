    private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        //Makes sure that a valid cell was double clicked.
        if (e.ColumnIndex > -1 && e.RowIndex > -1)
        {
            Form1 form = new Form1();
            form.pageInput.Text = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
            string input = form.pageInput.Text;
            form.loadPage(input);
        }
    }
