    private void timer1_Tick(object sender, EventArgs e)
        {    
            if (dataGridViewX1.RowsDefaultCellStyle.BackColor == Color.Red)
            {
                dataGridViewX1.RowsDefaultCellStyle.BackColor = Color.White;
                return;
            }
            if (dataGridViewX1.RowsDefaultCellStyle.BackColor == Color.White)
            {
                dataGridViewX1.RowsDefaultCellStyle.BackColor = Color.Red;
                return;
            }
         }
