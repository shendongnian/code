    dataGridView1.Columns["ColumnName"].Visible = false;
    int[] arr1 = new int[] { 0, 2 };
    foreach (int ColIndex in arr1)
        dataGridView1.Columns[ColIndex].Visible = false;
    int[] arr2 = new int[] { 1, 3 };
    foreach (int ColIndex in arr2)
        dataGridView2.Columns[ColIndex].Visible = false;
