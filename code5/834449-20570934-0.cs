    [HttpPost]
    public ActionResult ProcessSubmitUpload(HttpPostedFileBase attachments, Guid? idDocument)
    {
          //Validations
          var xmlDocument = XDocument.Load(attachments.InputStream);
          try
          {
              DocumentCommonHelper.SendFile(xmlDocument);
          }
          catch(Exception ex)
          {
              ModelState.AddModelError("ProcessSubmitUpload", ex.Message);
              return View(new MyViewModel())
          }
    }
