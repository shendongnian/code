    PdfPTable table = new PdfPTable(2);
    table.TotalWidth = 500;
    table.SetTotalWidth(new float[] { 30f, 400f });
    
    PdfPCell c1 = new PdfPCell();
    PdfPCell c2 = new PdfPCell();
    
    c1.AddElement(new Phrase("first column"));
    c1.AddElement(new Phrase("second column"));
    
    table.Rows.Add(new PdfPRow(new PdfPCell[] { c1, c2 }));
