    //Bytes will hold our final PDFs
    byte[] bytes;
    //Create an in-memory PDF
    using (var ms = new MemoryStream()) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, ms)) {
                doc.Open();
                //Create a bunch of pages and add text, nothing special here
                for (var i = 1; i <= 10; i++) {
                    doc.NewPage();
                    doc.Add(new Paragraph(String.Format("First Pass - Page {0}", i)));
                }
                doc.Close();
            }
        }
        //Right before disposing of the MemoryStream grab all of the bytes
        bytes = ms.ToArray();
    }
    //Another in-memory PDF
    using (var ms = new MemoryStream()) {
        //Bind a reader to the bytes that we created above
        using (var reader = new PdfReader(bytes)) {
            //Store our page count
            var pageCount = reader.NumberOfPages;
            //Bind a stamper to our reader
            using (var stamper = new PdfStamper(reader, ms)) {
                //Setup a font to use
                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //Loop through each page
                for (var i = 1; i <= pageCount; i++) {
                    //Get the raw PDF stream "on top" of the existing content
                    var cb = stamper.GetOverContent(i);
                    //Draw some text
                    cb.BeginText();
                    cb.SetFontAndSize(baseFont, 18);
                    cb.ShowText(String.Format("Second Pass - Page {0}", i));
                    cb.EndText();
                }
            }
        }
        //Once again, grab the bytes before closing things out
        bytes = ms.ToArray();
    }
    //Just to see the final results I'm writing these bytes to disk but you could do whatever
    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    System.IO.File.WriteAllBytes(testFile, bytes);
