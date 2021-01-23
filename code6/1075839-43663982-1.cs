    // byte[] fileBytes = getFileBytesFromDB();
    var tmpFile = Path.GetTempFileName();
    File.WriteAllBytes(tmpFile, fileBytes);
     
    Application app = new word.Application();
    Document doc = app.Documents.Open(filePath);
     
    // Save DOCX into a PDF
    var pdfPath = "path-to-pdf-file.pdf";
    doc.SaveAs2(pdfPath, word.WdSaveFormat.wdFormatPDF);
     
    doc.Close();
    app.Quit(); // VERY IMPORTANT: do this to close the MS Word instance
    byte[] pdfFileBytes = File.ReadAllBytes(pdfPath);
    File.Delete(tmpFile);
