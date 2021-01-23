    var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
    
    using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
        using (var doc = new Document()) {
            using (var writer = PdfWriter.GetInstance(doc, fs)) {
                doc.SetMargins(0, 0, 0, 0);
                doc.Open();
                
    
                var img1 = iTextSharp.text.Image.GetInstance(CreateImage("Hello", 24, 600, 50));
                doc.Add(img1); //72 DPI
    
                var img2 = iTextSharp.text.Image.GetInstance(CreateImage("Hello", 48, 1200, 100));
                img2.ScaleAbsolute(600, 50);
                doc.Add(img2); //144 DPI
    
                var img3 = iTextSharp.text.Image.GetInstance(CreateImage("Hello", 96, 2400, 200));
                img3.ScaleAbsolute(600, 50);
                doc.Add(img3); //288 DPI
    
                var img4 = iTextSharp.text.Image.GetInstance(CreateImage("Hello", 192, 4800, 400));
                img4.ScaleAbsolute(600, 50);
                doc.Add(img4); //576 DPI
    
    
                doc.Close();
            }
        }
    }
