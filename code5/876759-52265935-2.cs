    using (var package = new ExcelPackage(new FileInfo(file)))
    {
        //what i've seen used the most, entry point is the worksheet not the table w/i the worksheet(s)
        using (var worksheet = package.Workbook.Worksheets.FirstOrDefault())
        {
            if (worksheet != null)
            {
                for (int rowIndex = worksheet.Dimension.Start.Row; rowIndex <= worksheet.Dimension.End.Row; rowIndex++)
                {
                    var row = worksheet.Row(rowIndex);
                    //from comments here... https://github.com/JanKallman/EPPlus/wiki/Addressing-a-worksheet
                    //#:# gets entire row, A:A gets entire column
                    var rowCells = worksheet.Cells[$"{rowIndex}:{rowIndex}"];
                    //returns System.Object[,]
                    //type is string so it likely detects many cells and doesn't know how you want the many formatted together...
                    var rowCellsText = rowCells.Text;
                    var rowCellsTextMany = string.Join(", ", rowCells.Select(x => x.Text));
                    var allEmptyColumnsInRow = rowCells.All(x => string.IsNullOrWhiteSpace(x.Text));
                    var firstCellInRowWithText = rowCells.Where(x => !string.IsNullOrWhiteSpace(x.Text)).FirstOrDefault();
                    var firstCellInRowWithTextText = firstCellInRowWithText?.Text;
                    var firstCellFromRow = rowCells[rowIndex, worksheet.Dimension.Start.Column];
                    var firstCellFromRowText = firstCellFromRow.Text;
                    //throws exception...
                    //var badRow = rowCells[worksheet.Dimension.Start.Row - 1, worksheet.Dimension.Start.Column - 1];
                    //for me this happened on row1 + row2 beign merged together for the column headers
                    //not sure why the row.merged property is false for both rows though
                    if (allEmptyColumnsInRow)
                        continue;
                    for (int columnIndex = worksheet.Dimension.Start.Column; columnIndex <= worksheet.Dimension.End.Column; columnIndex++)
                    {
                        var column = worksheet.Column(columnIndex);
                        var currentRowColumn = worksheet.Cells[rowIndex, columnIndex];
                        var currentRowColumnText = currentRowColumn.Text;
                        var currentRowColumnAddress = currentRowColumn.Address;
                        //likely won't need to do this, but i wanted to show you can tangent off at any level w/ that info via another call
                        //similar to row, doing A:A or B:B here, address is A# so just get first char from address
                        var columnCells = worksheet.Cells[$"{currentRowColumnAddress[0]}:{currentRowColumnAddress[0]}"];
                        var columnCellsTextMany = string.Join(", ", columnCells.Select(x => x.Text));
                        var allEmptyRowsInColumn = columnCells.All(x => string.IsNullOrWhiteSpace(x.Text));
                        var firstCellInColumnWithText = columnCells.Where(x => !string.IsNullOrWhiteSpace(x.Text)).FirstOrDefault();
                        var firstCellInColumnWithTextText = firstCellInColumnWithText?.Text;
                    }
                }
            }
        }
    }
