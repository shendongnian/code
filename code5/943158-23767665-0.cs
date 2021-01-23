    public ActionResult Create(Model myModel, HttpPostedFileBase fileUpload)
    { 
        byte[] Data = null;
                        
        using (var binaryReader = new BinaryReader(fileUpload.InputStream))
        {
            Data = binaryReader.ReadBytes(fileUpload.ContentLength);
        }
    }
