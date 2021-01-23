        private void datagrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Calculate();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            Calculate();
        }
        private void Calculate()
        {
            double value1 = datagrid.Rows[e.RowIndex].Cells[2].Value == DBNull.Value ? 0 : Convert.ToDouble(datagrid.Rows[e.RowIndex].Cells[2].Value);
            double value2 = datagrid.Rows[e.RowIndex].Cells[3].Value == DBNull.Value ? 0 : Convert.ToDouble(datagrid.Rows[e.RowIndex].Cells[3].Value);
            double value3 = datagrid.Rows[e.RowIndex].Cells[4].Value == DBNull.Value ? 0 : Convert.ToDouble(datagrid.Rows[e.RowIndex].Cells[4].Value);
            double value4 = datagrid.Rows[e.RowIndex].Cells[5].Value == DBNull.Value ? 0 : Convert.ToDouble(datagrid.Rows[e.RowIndex].Cells[5].Value);
            datagrid.Rows[e.RowIndex].Cells[6].Value = ((value2 + (value3/100)) * value1) - (value4/100);
    
            if (e.ColumnIndex == 5)
            {
                summition();
            }
        }
