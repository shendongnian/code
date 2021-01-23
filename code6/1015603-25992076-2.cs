    foreach(var dto in importDtos)
    {
    var row = new TableRow();
    
    var identifierCell = new TableCell();
    var valueCell = new TableCell();
    
    identifierCell.Controls.Add(new LiteralControl(dto.RowIdentifier));
    valueCell.Controls.Add(new LiteralControl(dto.RowValue ));
    
    row.Add(identifierCell);
    row.Add(valueCell);
    
    tblImportPreview.Controls.Add(row);
    }
