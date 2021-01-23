        object previousValue;
        public Form1()
        {
            dgv.CellBeginEdit += dgv_CellBeginEdit;
            dgv.CellEndEdit += dgv_CellEndEdit;
        }
        void dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv[e.ColumnIndex, e.RowIndex].Value != previousValue) 
                  dgv[e.ColumnIndex, e.RowIndex].Style.ForeColor = Color.Red;
        }
        void dgv_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            previousValue = dgv[e.ColumnIndex, e.RowIndex].Value;
        }
