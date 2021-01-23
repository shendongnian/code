    public void CreatePackage()
    {
      using (MemoryStream mem = new MemoryStream())
      {
        using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(mem, WordprocessingDocumentType.Document))
        {
          CreateParts(wordDocument);
          Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
          Microsoft.Office.Interop.Word.Document doc = app.Documents.Add(System.Type.Missing, System.Type.Missing, System.Type.Missing, System.Type.Missing);
    	  XDocument xDoc = OPCHelper.OpcToFlatOpc(wordDocument.Package);
    	  string openxml = xDoc.ToString();                        
    	  doc.Range().InsertXML(openxml);
          doc.Activate();
        }
      }
    }
