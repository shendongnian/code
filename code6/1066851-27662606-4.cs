    if (FileUpload1.HasFile)
    {
        HttpPostedFile myPostedFile = FileUpload1.PostedFile;
        FileInfo finfo = new FileInfo(myPostedFile.FileName);
        if (finfo.Extension.Equals(".pdf", StringComparison.InvariantCultureIgnoreCase) && IsPdf(finfo.FullName))
        {
            //do the operation
        }
    }
    public bool IsPdf(string sourceFilePath)
    {
      var bytes = System.IO.File.ReadAllBytes(sourceFilePath);
      var match = System.Text.Encoding.UTF8.GetBytes("%PDF-");
      return match.SequenceEqual(bytes.Take(match.Length));
    }
