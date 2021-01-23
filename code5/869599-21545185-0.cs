    PdfPTable table = new PdfPTable(3);
    PdfPCell cell = new PdfPCell(new Phrase("Header spanning 3 columns"));
    cell.Colspan = 3;
    cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
    table.AddCell(cell);
    table.AddCell("Col 1 Row 1");
    table.AddCell("Col 2 Row 1");
    table.AddCell("Col 3 Row 1");
    
    PdfPCell cellBlankRow = new PdfPCell(new Phrase(" "));
    cell.Colspan = 3;
    cell.HorizontalAlignment = 1;
    table.AddCell(cellBlankRow);
    table.AddCell("");
    table.AddCell("");
                
    table.AddCell("Col 1 Row 2");
    table.AddCell("Col 2 Row 2");
    table.AddCell("Col 3 Row 2");
