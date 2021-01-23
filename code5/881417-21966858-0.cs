                var t = new PdfPTable(1);
                t.ExtendLastRow = true;
                t.WidthPercentage = 100; 
    
                var c = new PdfPCell();
                c.VerticalAlignment = Element.ALIGN_BOTTOM;
                c.DisableBorderSide(Rectangle.BOX);
    
                var p = new Paragraph("This is a test. This is a test. This is a test. This is a test. This is a test. This is a test. This is a test. This is a test. This is a test.");
                p.Alignment = Element.ALIGN_JUSTIFIED;
    
                c.AddElement(p);
   
                t.AddCell(c);
                doc.Add(t);
