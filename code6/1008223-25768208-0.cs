    //We need a font that supports Cyrillic glyphs
    var fontFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIALUNI.TTF");
    
    //Create an iText font that uses this font
    var bf = BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
    
    //Create our barcode
    var B = new iTextSharp.text.pdf.BarcodeInter25();
    
    //Set the font
    B.Font = bf;
    
    //Set the text, you might need to play with the whitespace
    B.Code = "693000   78   00700   4";
    
    //Generate an iTextSharp image which is vector-based
    var img = B.CreateImageWithBarcode(writer.DirectContent, BaseColor.BLACK, BaseColor.BLACK);
    
    //Shrink the image to fit specific bounds
    img.ScaleToFit(100, 100);
    
    //The barcode above doesn't support drawing text on top but we can easily do this
    //Also, the OP is using a PdfStamper so this easily works with that path, too
    
    //Create a ColumnText object bound to a canvas.
    //For a PdfStamper this would be something like mPdfStamper.GetOverContent(2)
    var ct = new ColumnText(writer.DirectContent);
    
    //Set the boundaries of the object
    ct.SetSimpleColumn(100, 400, 300, 600);
    
    //Add our text using our specified font and size
    ct.AddElement(new Paragraph("ПОЧТА РОССИИ", new iTextSharp.text.Font(bf, 10)));
    
    //Add our barcode
    ct.AddElement(img);
    
    //Draw the barcode onto the canvas
    ct.Go();
