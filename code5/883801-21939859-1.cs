    var subTable = new PdfPTable(new float[] { 10, 100 });                        
    subTable.AddCell(new PdfPCell(new Phrase("First line text")) { Colspan = 2, Border = 0 });
    subTable.AddCell(new PdfPCell() { Border = 0 });
    subTable.AddCell(new PdfPCell(new Phrase("Second line text")) {  Border = 0 });
    subTable.AddCell(new PdfPCell() { Border = 0 });
    subTable.AddCell(new PdfPCell(new Phrase("Third line text")) { Border = 0 });
    subTable.AddCell(new PdfPCell(new Phrase("Fourth line text")) { Colspan = 2, Border = 0 });
    myTable.AddCell(subTable);
