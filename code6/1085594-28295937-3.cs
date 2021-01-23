    [HttpPost]
    public ActionResult CreateDocument(HttpPostedFileBase file, string fileType)
    {
      if (file != null && file.ContentLength > 0)
      {
        Document doc = new Document()
        {
          Filetype = fileType
        }
        if (this.TryValidateModel(doc))
        {
          this.dbContext.Add(doc);
          this.dbContext.SaveChanges();
          id = doc.ID;
          //save document using document ID
        }
      }
    }
