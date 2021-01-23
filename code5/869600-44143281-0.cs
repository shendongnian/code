    PdfPTable table = new PdfPTable(3);
    PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
    cell.Colspan = 3;
    cell.HorizontalAlignment = 1;
    table.AddCell(cell);
    table.AddCell("Col 1 Row 1");
    table.AddCell("Col 2 Row 1");
    table.AddCell("Col 3 Row 1");
    
    //For blank line
     PdfPCell blankCell = new PdfPCell(new Phrase(Chunk.NEWLINE));
     blankCell.Border = PdfPCell.NO_BORDER;
     table.AddCell(blankCell);
                
    
    table.AddCell("Col 1 Row 2");
    table.AddCell("Col 2 Row 2");
    table.AddCell("Col 3 Row 2");
    doc.Add(table);
