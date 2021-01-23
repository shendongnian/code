    public void SetValue(int row, string column, string value)
    {
        row += 2;   //EPPlus is 1-index based, and the first row is the heading
        int columnIndex = this.GetColumnIndex(column);
        this.excelSheet.SetValue(row, columnIndex, value);
    }
