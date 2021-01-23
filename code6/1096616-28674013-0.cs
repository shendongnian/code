    string srcFile = @"C:\Users\steve\Desktop\original.pdf";
    string dstFile = @"C:\Users\steve\Desktop\result.pdf";
    PdfReader reader = new PdfReader(srcFile);
    ICollection<int> pagesToKeep = new List<int>();
    for (int page = 1; page <= reader.NumberOfPages; page++)
    {
        // Use the text extraction strategy of your choice here...
        ITextExtractionStrategy strategy = new SimpleTextExtractionStrategy();
        string currentText = PdfTextExtractor.GetTextFromPage(reader, page, strategy);
        // Use the content text test of your choice here...
        if (currentText.IndexOf("special") > 0)
        {
            pagesToKeep.Add(page);
        }
    }
    // Copy selected pages using PdfCopy
    Document document = new Document();
    PdfCopy copy = new PdfCopy(document, new FileStream(dstFile, FileMode.Create));
    document.Open();
    foreach (int page in pagesToKeep)
    {
        PdfImportedPage importedPage = copy.GetImportedPage(reader, page);
        copy.AddPage(importedPage);
    }
    document.Close();
    reader.Close();
