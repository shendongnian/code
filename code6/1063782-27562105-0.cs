    public ActionResult OpenDocument(int documentID)
    {
       Document doc = Model.DocumentServiceHelper.GetSingleDocument(documentID);
    
       if (doc != null)
       {
           return File(doc.Data, MimeMapping.GetMimeMapping(doc.Name) + doc.Name);
       }
       return Json("No File", JsonRequestBehavior.AllowGet);
    }
