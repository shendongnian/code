    void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex != qntyColumnIndex) { return; }
        quantity = Convert.ToDecimal(
            GridSellProducts.Rows[e.RowIndex]
                            .Cells["Qnty"].Value);
    }
