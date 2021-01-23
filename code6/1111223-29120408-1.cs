    var tables = mainPart.Document.Descendants<Table>().ToList();
    foreach (Table t in tables)
    {
        var rows = t.Elements<TableRow>();
        foreach (TableRow row in rows)
        {
            var cells = row.Elements<TableCell>();
            foreach (TableCell cell in cells) 
                ...
        }
    }
