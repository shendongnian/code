    public ActionResult Upload(HttpPostedFileBase files)
    {
         byte[] fileData = null;
         using (var binaryReader = new BinaryReader(files.InputStream))
         {
            fileData = binaryReader.ReadBytes(files.ContentLength);
         }  
         ProjectFile projectObj = reader.read(new ByteArrayInputStream(fileData));
    }
