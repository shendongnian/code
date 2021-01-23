    public void printausfueren()
    {
        //(some Code)
        object[] rows = { sqlReader[0], sqlReader[1], sqlReader[3], sqlReader[2], sqlReader[4], sqlReader[5], sqlReader[6], sqlReader[7] };
        dataGridViewPrint.Invoke(new Action(() => LoadGrid(rows)));
        //(some Code)
    }
    private void LoadGrid(object[] rows)
    {
        // only need BeginEdit/EndEdit if you are adding many rows at a time
        dataGridViewPrint.BeginEdit(false);
        dataGridViewPrint.Rows.Add(rows);
        dataGridViewPrint.EndEdit();
    }
