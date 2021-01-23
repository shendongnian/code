    private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                DataGridView1["Your Column Index", e.RowIndex].Value = Convert.ToBoolean(DataGridView1["Your Column Index", e.RowIndex].Value);
            }
    
    private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (Convert.ToBoolean(DataGridView1["Your Column Index", e.RowIndex].Value))
                {
                    DataGridView1["Your Column Index", e.RowIndex].Value = false;
                }
                else
                {
                    DataGridView1["Your Column Index", e.RowIndex].Value = true ;
                }
            }
