    var directoryPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/uploads/attachments/CustomerWorkSheet");
    var file = Directory.EnumerateFiles(directoryPath).SingleOrDefault(f => f.Contains("CustomerWorkSheet/" + myCustomerId));
    if(file != null){
      IWordDocument doc = new WordDocument();
      doc.open(file, FormatType.Doc);
    }
