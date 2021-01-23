    public FileResult OpenDocument(int documentID)
    {
       Document doc = Model.DocumentServiceHelper.GetSingleDocument(documentID);
       return File(doc.Data, System.Net.Mime.MediaTypeNames.Application.Octet, doc.Name);
    }
