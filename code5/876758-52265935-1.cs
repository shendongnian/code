    //for some reason, if i don't instantiating another package and i work with the 'Tables' property in any way, the API throws a...
    //Object reference not set to an instance of an object.
    //at OfficeOpenXml.ExcelWorksheet.get_Tables()
    //excetion... this is because i have data in my worksheet but not an actual 'table' (Excel => Insert => Table)
    //a parital load of worksheet cell data + invoke to get non-existing tables must have a bug as below code does not
    //throw an exception and detects null gracefully on firstordefault
    using (var package = new ExcelPackage(new FileInfo(file)))
    {
        //however, question was about a table, so lets also look at that... should be the same?
        //no IDisposable? :(
        //adding a table manually to my worksheet allows the 'same-ish' (child.Parent, aka table.WorkSheet) code to iterate
        var table = package.Workbook.Worksheets.SelectMany(x => x.Tables).FirstOrDefault();
        if (table != null)
        {
            for (int rowIndex = table.Address.Start.Row; rowIndex < table.Address.End.Row; rowIndex++)
            {
                var row = table.WorkSheet.Row(rowIndex);
                var rowCells = table.WorkSheet.Cells[$"{rowIndex}:{rowIndex}"];
                var rowCellsManyText = string.Join(", ", rowCells.Select(x => x.Text));
                for (int columnIndex = table.Address.Start.Column; columnIndex < table.Address.End.Column; columnIndex++)
                {
                    var currentRowColumn = table.WorkSheet.Cells[rowIndex, columnIndex];
                    var currentRowColumnText = currentRowColumn.Text;
                }
            }
        }
    }
