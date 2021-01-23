    DateTime yourCompareDate = DateTime.Now;
    foreach (DataGridViewRow r in dataGridView1.Rows)
    {
        DateTime cellValue7 = Convert.ToDateTime(r.Cells[6].Value); //Convert/Cast value to date
        if(cellValue7 > yourCompareDate)
        {
            r.DefaultCellStyle.BackColor = Color.Red;
        }
    }
