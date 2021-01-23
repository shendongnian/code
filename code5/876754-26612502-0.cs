    public static IEnumerable<IDictionary<string, object>> GetRows(this ExcelTable table)
    {
        var addr = table.Address;
        var cells = table.WorkSheet.Cells;
        var firstCol = addr.Start.Column;
        var firstRow = addr.Start.Row;
        if (table.ShowHeader)
            firstRow++;
        var lastRow = addr.End.Row;
        for (int r = firstRow; r <= lastRow; r++)
        {
            yield return Enumerable.Range(0, table.Columns.Count)
                .ToDictionary(x => table.Columns[x].Name, x => cells[r, firstCol + x].Value);
        }
    }
