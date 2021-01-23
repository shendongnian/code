    public void AddImage(Document doc, iTextSharp.text.Image Image)
    {
        PdfPTable table = new PdfPTable(1);
        table.WidthPercentage = 100;
    
        PdfPCell c = new PdfPCell(Image, true);
        c.Border = PdfPCell.NO_BORDER;
        c.Padding = 5;
        c.Image.ScaleToFitHeight = false; /*The new line*/
    
        table.AddCell(c);
    
        doc.Add(table);
    }
