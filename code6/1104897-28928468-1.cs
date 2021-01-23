    string dir = @"C:\slim\slimyyyy";
    if (Directory.Exists(dir))
    {
        string[] pdf_specFiles = Directory.GetFiles(dir);
        if (pdf_specFiles.Length > 0)
        {
            List<string> printList = GetMissingFiles(rchTextContent.Lines, pdf_specFiles);
            // do something with printList
        }
    }
