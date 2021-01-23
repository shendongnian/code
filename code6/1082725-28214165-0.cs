    public void DoSpecialAction(PdfStamper pdfStamper)
    {
        using (var pdfTemplate = new PdfReader(_extraPageTemplatePath))
        using (var pdfReader = new PdfReader(pdfTemplate))
        {
            PdfImportedPage page = pdfStamper.GetImportedPage(pdfReader, 1);
            pdfStamper.InsertPage(3, pdfReader.GetPageSize(1));
            PdfContentByte pb = pdfStamper.GetUnderContent(3);
            pb.AddTemplate(page, 0, 0);
            // Copy everything required from the PdfReader
            pdfStamper.Writer.FreeReader(pdfReader);
        }
    }
