    public ActionResult Create(AdminDetailsModel viewmodel)
    {
        if (ModelState.IsValid)
        {
        HttpPostedFileBase file = Request.Files["ImageData"];
        viewmodel.Image = ConvertToByte(file);
        db.YourDbContextSet.Add(viewmodel);
        db.SaveChanges();
        }
    }
    public byte[] ConvertToByte(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            BinaryReader rdr = new BinaryReader(file.InputStream);
            imageByte = rdr.ReadBytes((int)file.ContentLength);
            return imageByte;
        }
