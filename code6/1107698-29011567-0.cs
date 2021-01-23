    //Create a sample multiple page PDF and place it on the desktop
    var outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "t5.pdf");
    using (var fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                for (var i = 0; i < 1000; i++) {
                    doc.Add(new Paragraph(String.Format("This is paragraph #{0}", i)));
                }
                doc.Close();
            }
        }
    }
