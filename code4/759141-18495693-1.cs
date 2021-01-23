    int totalObjects = rivers.Count;
    int totalCells = desiredRows * desiredColumns;
    HtmlTableRow newRow = new HtmlTableRow();
    for( i = 0; i < totalCells; i++ )
    {
        // make a new row when you get the desired number of columns
        // skip the first, empty row
        if( i % desiredColumns == 0 && i != 0 )
        {
            myTable.Rows.Add( newRow );
            newRow = new HtmlTableRow();
        }
        // keep putting in cells
        if( i < totalObjects )
            row.Cells.Add(new HtmlTableCell(rivers[i]));
        // if we have no more objects, put in empty cells to fill out the table
        else
            row.Cells.Add(new HtmlTableCell(""));
    }
