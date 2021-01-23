    //Will hold our PDF as a byte array
    Byte[] bytes;
    //Create a sample multiple page PDF, nothing special here
    using (var ms = new MemoryStream()) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, ms)) {
                doc.Open();
                for (var i = 0; i < 1000; i++) {
                    doc.Add(new Paragraph(String.Format("This is paragraph #{0}", i)));
                }
                doc.Close();
            }
        }
        //Store our bytes before
        bytes = ms.ToArray();
    }
    //Read our sample PDF and apply page numbers
    using (var reader = new PdfReader(bytes)) {
        using (var ms = new MemoryStream()) {
            using (var stamper = new PdfStamper(reader, ms)) {
                int PageCount = reader.NumberOfPages;
                for (int i = 1; i <= PageCount; i++) {
                    ColumnText.ShowTextAligned(stamper.GetOverContent(i), Element.ALIGN_CENTER, new Phrase(String.Format("Page {0} of {1}", i, PageCount)), 100, 10 , 0);
                }
            }
            bytes = ms.ToArray();
        }
    }
    var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "t5.pdf");
    System.IO.File.WriteAllBytes(outputFile, bytes);
