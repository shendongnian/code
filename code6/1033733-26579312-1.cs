    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
        if (articles.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn)) {
                articles.Rows[e.RowIndex].Cells[e.ColumnIndex].EditMode = DataGridViewEditMode.EditProgrammatically;
                articles.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "Done";
        }
    }
