    public string GetColumnName(IXLTable table, string columnHeader)
    {
        var cell = table.HeadersRow().CellsUsed(c => c.Value == "Something").FirstOrDefault();
        if (cell != null)
        {
            return cell.WorksheetColumn().ColumnLetter();
        }
        return null;
    }
