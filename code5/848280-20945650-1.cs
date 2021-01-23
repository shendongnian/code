    int i = 0;
    List<string> AbDates = new List<string>();
    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
    string dt = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    if (string.IsNullOrEmpty(dt))
    { 
    }
    else
    {
    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor == Color.Red)
    {
    if (MessageBox.Show("Do you  want to UnMark this ?", "UnMark", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
    {
    }
    else
    {
    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.White;
    dt = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    AbDates.Add(AbDates.Where(val => val != dt).ToList());
    i--;
    }
    }
    else
    {
    if (MessageBox.Show("Do you  want to Mark this As Absent?", "Absent", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
    {
    }
    else
    {
    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Red;
    dt = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
    //  MessageBox.Show(i.ToString());
    AbDates[i].Add(dt);
    i++;
    }
    }
    }
