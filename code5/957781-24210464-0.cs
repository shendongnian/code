    private void PopulateGrid(params List<string>[] list)
    {
        DataTable dtTable = new DataTable();
        for (int listIndex = 0; listIndex < list.Length; listIndex++)
        {
            dtTable.Columns.Add(string.Format("Column{0}", listIndex), typeof(string));
        }
    
        for (int rowIndex = 0; rowIndex < list[0].Count; rowIndex++)
        {
            DataRow dr = dtTable.NewRow();
            for (int listIndex = 0; listIndex < list.Length; listIndex++)
            {
                dr[listIndex] = list[listIndex][rowIndex];
            }
            dtTable.Rows.Add(dr);
        }
        dataGridView1.DataSource = dtTable;
    }
	
