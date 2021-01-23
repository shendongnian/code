    private void dataGridView1_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
        if (e.CellValue1 == e.CellValue2)
        {
            string altCol = "Name";
            if (e.Column.Name == "Name")  altCol = "Status";
                
            string s1 = dataGridView1[altCol, e.RowIndex1].Value.ToString();
            string s2 = dataGridView1[altCol, e.RowIndex2].Value.ToString();
            e.SortResult = String.Compare(s1, s2);
            e.Handled = true;
        }
    }
