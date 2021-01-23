        foreach (Message message in lbMessages.Items)
                {
    
                    TableRowGroup _MessageContainer = new TableRowGroup();
                    
                    // Rows
                    TableRow _TimeCreated = new TableRow();
                    TableRow _imageRow = new TableRow();
                    TableRow _TimeRow = new TableRow();
    
                    // first row
                    TableCell xcell = new TableCell(new Paragraph(new Run("Image is here")));
                    xcell.RowSpan = 2;
                    TableCell _TimeCell = new TableCell(new Paragraph(new Run(message.TimeCreated.ToString())));
                    _TimeCreated.Cells.Add(xcell);
                    _TimeCreated.Cells.Add(_TimeCell);
    
                    // Second Row.
                    xcell = new TableCell(new Paragraph(new Run(message.MessageBody)));
                    _imageRow.Cells.Add(xcell);
    
                    // Third Row
                    xcell = new TableCell(new Paragraph(new Run(message.Sender)));
                    xcell.ColumnSpan = 2;
    
                    _MessageContainer.Rows.Add(_TimeCreated);
                    _MessageContainer.Rows.Add(_imageRow);
                    _MessageContainer.Rows.Add(_TimeRow);
    
                    Table xtable = new Table();
                    xtable.RowGroups.Add(_MessageContainer);
                    xtable.CellSpacing = 3;
                    xtable.Background = Brushes.White;
    
                    document.Blocks.Add(xtable);
    }
