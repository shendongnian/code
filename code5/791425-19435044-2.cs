    using (WordprocessingDocument mainDoc = WordprocessingDocument.Open("mydoc.docx", true))
    {
      foreach (var item in mainDoc.MainDocumentPart.FooterParts)
      {
        ProcessParaIncludeTextMerge(item, item.Footer.Descendants<Run>(), mainDoc);
        item.Footer.Save();
      }
      mainDoc.MainDocumentPart.Document.Save();           
    }
