    PdfPTable table = new PdfPTable(3);
    // the cell object
    PdfPCell cell;
    // we add a cell with colspan 3
    cell = new PdfPCell(new Phrase("Cell with colspan 3"));
    cell.Colspan = 3;
    table.AddCell(cell);
    // now we add a cell with rowspan 2
    cell = new PdfPCell(new Phrase("Cell with rowspan 2"));
    cell.Rowspan = 2;
    table.AddCell(cell);
    // we add the four remaining cells with addCell()
    table.AddCell("row 1; cell 1");
    table.AddCell("row 1; cell 2");
    table.AddCell("row 2; cell 1");
    table.AddCell("row 2; cell 2");
