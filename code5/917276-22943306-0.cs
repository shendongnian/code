    using (var pdfReader = new PdfReader(content))
    using (var fileStream = new FileStream(newFile, FileMode.Create, FileAccess.Write,FileShare.ReadWrite))
    using (var document = new Document(pdfReader.GetPageSizeWithRotation(1)))
    using (var writer = PdfWriter.GetInstance(document, fileStream))
    {
      document.Open();                                                        
      for (var i = 1; i <= pdfReader.NumberOfPages; i++)
      {
        document.NewPage();
        var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        var importedPage = writer.GetImportedPage(pdfReader, i);
        var contentByte = writer.DirectContent;
        contentByte.BeginText();
        contentByte.SetFontAndSize(baseFont, 12);
        string mytext = " ";                                                          
    
        contentByte.ShowTextAligned(2, mytext, 100, 200, 0);
        contentByte.EndText();
        contentByte.AddTemplate(importedPage, 0, 0);
      }
      // These lines may be unnecessary.
      writer.Close();
      document.Close();
      fileStream.Close();
      pdfReader.Close();
    }
 
