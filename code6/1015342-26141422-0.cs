    using (var document = new Document(PageSize.A4))
    {
        PdfWriter.GetInstance(document, new FileStream(path, FileMode.Create));
        document.Open();
    
        var paragraph = new Paragraph();
    
        var image = Image.GetInstance(@"C:\image1.jpg");
        
        var table = new PdfPTable(1);
    
        var cell = new PdfPCell { PaddingLeft = 5, PaddingTop = 5, PaddingBottom = 5, PaddingRight = 5 };
    
        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        cell.AddElement(paragraph);
    
        table.AddCell(cell);
    
      //image.ScaleToFit(JpgBg.Width, JpgBg.Height);
       image.ScaleAbsolute(table.Width, table.Height);
       image.Alignment = iTextSharp.text.Image.UNDERLYING;
       document.Add(image);
    
        document.Add(table);
    
        document.Close();
    }
                       
                       
