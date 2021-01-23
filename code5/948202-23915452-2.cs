    //Our test file
    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    //Create our test file, nothing special
    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.Open();
                doc.Add(new Paragraph("This is my sample file"));
                doc.Close();
            }
        }
    }
    //Create an instance of our strategy
    var t = new MyLocationTextExtractionStrategy();
    //Parse page 1 of the document above
    using (var r = new PdfReader(testFile)) {
        var ex = PdfTextExtractor.GetTextFromPage(r, 1, t);
    }
    //Loop through each chunk found
    foreach (var p in t.myPoints) {
        Console.WriteLine(string.Format("Found text {0} at {1}x{2}", p.Text, p.Rect.Left, p.Rect.Bottom));
    }
