    if (docType.Contains("pdf"))
    {
        MemoryStream ms = new MemoryStream(docData.ToArray());
        PdfReader pdfReader = new PdfReader(ms);
        for (int i = 1; i <= pdfReader.NumberOfPages; i++)
        {
            PdfImportedPage page = writer.GetImportedPage(pdfReader, i);
            document.Add(iTextSharp.text.Image.GetInstance(page));
        }
    }
