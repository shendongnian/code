    using(MemoryStream outPDF = new MemoryStream())
    {
        using (PdfReader pdfr = new PdfReader(inPDF))
        {
            using (Document doc = new Document(PageSize.LETTER))
            {
                //...
            }
        }
        return outPDF.ToArray();
    }
