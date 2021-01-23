    private void ExtractPages(string sourcePDFpath, string outputPDFpath, int startpage, int endpage)
    {
      var pdfReader = new PdfReader(sourcePDFpath);
      try
      {
        pdfReader.SelectPages($"{startpage}-{endpage}");
        using (var fs = new FileStream(outputPDFpath, FileMode.Create, FileAccess.Write))
        {
          PdfStamper stamper = null;
          try
          {
            stamper = new PdfStamper(pdfReader, fs);
          }
          finally
          {
            stamper?.Close();
          }
        }
      }
      finally
      {
        pdfReader.Close();
      }
    }
