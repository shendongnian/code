    // here should be the code opening the document and getting the table element
    // ...
    // I assume table element is assigned to *table* variable
    var tableRows = table.ChildElements.OfType<TableRow>();
    foreach (var r in tableRows)
    {
        var tableCellsInRow = r.ChildElements.OfType<TableCell>();
        
        foreach (var c in tableCellsInRow)
        {
            string width = c.TableCellProperties.TableCellWidth.Width.Value;
        }
    }
