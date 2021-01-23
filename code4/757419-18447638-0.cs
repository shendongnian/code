    private void dataGridView1_KeyDown(Object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            if (shortMode)
            {
                dataGridView1.Rows[curRow].DefaultCellStyle.Format = ""; //Number with all the decimals
                shortMode = false;
            }
            else
            {
                dataGridView1.Rows[curRow].DefaultCellStyle.Format = "P1"; //Number as percentage with 1 decimal
                shortMode = true;
            }
        }
    }
