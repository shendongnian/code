    private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        DataGridViewImageCell cell = (DataGridViewImageCell) dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if (cell.Value=="sewagram express")
        {
            SqlCommand cm1 = new SqlCommand("select * from sewagram", con);
            DataTable dth = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cm1);
            da.Fill(dth);
            dataGridView1.DataSource = dth;
        }
    }
