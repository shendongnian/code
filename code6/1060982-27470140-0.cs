    dataGridView1.Tag = "DGV1";
    dataGridView2.Tag = "DGV2";
    dataGridView3.Tag = "DGV3";
    dataGridView4.Tag = "DGV4";
    dataGridView5.Tag = "DGV5";
    dataGridView6.Tag = "DGV6";
----------
    private void dataGridView_CellClick(object sender,
        DataGridViewCellEventArgs e)
    {
        DataGridView dgv = (DataGridView)sender;
        //Use case 1:
        string dgvTag = (string)dgv.Tag;
        switch(dgvTag)
        {
            case "DGV1": /*Do Something*/ break;
            case "DGV3": /*Do Something*/ break;
            case "DGV3": /*Do Something*/ break;
            case "DGV4": /*Do Something*/ break;
            case "DGV5": /*Do Something*/ break;
            case "DGV6": /*Do Something*/ break;
        }
        //Use case 2:
        DataGridViewImageCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
        MessageBox.Show((string)cell.Value);
    }
