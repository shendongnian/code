    cell.AddConditionalFormat()
        .WhenEquals(
            string.Format(
                "=TRUNC(${0}${1})", 
                cell.WorksheetColumn().ColumnLetter(),
                cell.WorksheetRow().RowNumber()))
        .NumberFormat
        .Format = "general\"%\"";
