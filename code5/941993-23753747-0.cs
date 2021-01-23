    public static void ExpandRepeatingPages(string sourcePdfPath, string outputPdfPath)
    {
        /* figure out how many pages we are working with */
        var transientPdfReader = new PdfReader(sourcePdfPath);
        var numberOfPages = transientPdfReader.NumberOfPages;
        transientPdfReader.Close();
    
        var outputFileStream = new FileStream(outputPdfPath, FileMode.Create);
        var pdfCopyFields = new PdfCopyFields(outputFileStream);
    
        foreach (var pageNumber in Enumerable.Range(1, numberOfPages))
        {
            var pdfBytes = ExtractPageToBytes(sourcePdfPath, pageNumber);
            var pdfReader = new PdfReader(pdfBytes);
            pdfCopyFields.AddDocument(pdfReader);
            pdfReader.Close();
    
            if (pageNumber == 2)
            {
                foreach (var extraPageNumber in Enumerable.Range(2, 200))
                {
                    var extraPagePdfBytes = RenamePageFields(pdfBytes, extraPageNumber);
                    pdfReader = new PdfReader(extraPagePdfBytes);
                    pdfCopyFields.AddDocument(pdfReader);
                    pdfReader.Close();
                }
            }
        }
    
        pdfCopyFields.Close();
    }
    
    public static byte[] ExtractPageToBytes(string sourcePdfPath, int pageNumber)
    {
        using (var memoryStream = new MemoryStream())
        {
            var pageNumbers = new System.Collections.ArrayList { pageNumber };
            var pdfReader = new PdfReader(sourcePdfPath);
            var pdfCopyFields = new PdfCopyFields(memoryStream);
    
            pdfReader.SelectPages(pageNumbers);
            pdfCopyFields.AddDocument(pdfReader);
            pdfReader.RemoveUnusedObjects();
            pdfCopyFields.Close();
            pdfReader.Close();
            return memoryStream.ToArray();
        }
    }
    
    private static byte[] RenamePageFields(byte[] pdfBytes, int pageNumber)
    {
        using (var memoryStream = new MemoryStream())
        {
            var pdfReader = new PdfReader(pdfBytes);
            var pdfStamper = new PdfStamper(pdfReader, memoryStream);
            var acroFields = pdfStamper.AcroFields;
            var fieldNames = acroFields.Fields.Keys.Cast<String>().ToList();
    
            foreach (var fieldName in fieldNames)
            {
                var newName = String.Format("{0}_{1}", fieldName, pageNumber);
                acroFields.RenameField(fieldName, newName);
            }
    
            pdfStamper.Close();
            pdfReader.Close();
            return memoryStream.ToArray();
        }
    }
