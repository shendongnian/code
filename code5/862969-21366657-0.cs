    private void timer1_Tick(object sender, EventArgs e)
    {
        foreach (DataGridViewRow y in dataGridViewX1.Rows)
                {
                    if (y.DefaultCellStyle.BackColor == Color.Red) y.DefaultCellStyle.BackColor = Color.White;
                    else if (y.DefaultCellStyle.BackColor == Color.White) y.DefaultCellStyle.BackColor = Color.Red;
                }
    }
