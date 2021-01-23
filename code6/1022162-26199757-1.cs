    private string GetCurrentOrFirstValOfColumn(string colName)
    {
        String colVal = String.Empty;
        DataGridViewRow dgvr = dataGridViewFileContents.CurrentRow;
        if (null != dgvr.Cells[colName].Value)
        {
            colVal = dgvr.Cells[colName].Value.ToString();
        }
        return colVal;
    }
