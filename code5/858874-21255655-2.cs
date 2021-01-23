    private void button1_Click(object sender, EventArgs e)
    {
        DataTable src1 = grv1.DataSource as DataTable;
        DataTable src2 = grv2.DataSource as DataTable;
        int index1 = 0;
        foreach (DataRow row1 in src1.Rows)
        {
            foreach (DataRow row2 in src2.Rows)
            {
                int index2 = 0;
                bool duplicateRow = true;
                for (int cellIndex = 0; cellIndex < row1.ItemArray.Count(); cellIndex++)
                {
                    if (!row1.ItemArray[cellIndex].ToString().Equals(row2.ItemArray[cellIndex].ToString()))
                    {
                        duplicateRow = false;
                        break;
                    }
                }
        
                if (duplicateRow)
                {
                    grv1.Rows[index1].DefaultCellStyle.BackColor = Color.Red;
                    grv2.Rows[index2].DefaultCellStyle.BackColor = Color.Red;
                }
                index2++;
            }
            index1++;
        }
    }
