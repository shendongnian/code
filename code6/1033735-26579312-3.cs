    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
        if (articles.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn)) {
                articles.EditMode = DataGridViewEditMode.EditProgrammatically;
                articles.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                articles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Done";
        }
    }
