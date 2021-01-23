    PdfReader reader = new PdfReader(pdf);
    // loop over all the pages in the original PDF
    int n = reader.NumberOfPages;      
    for (int i = 0; i < n; i++)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            // We'll create as many new PDFs as there are pages
            using (Document document = new Document())
            {
                using (PdfCopy copy = new PdfCopy(document, ms))
                {
                    document.Open();
                    copy.AddPage(copy.GetImportedPage(reader, i + 1));
                }
            }
            // store ms.ToArray() somewhere
        }
    }
