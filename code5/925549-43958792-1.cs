    if (ModelState.IsValid)
    {
        var old = db.Channel.Find(channel.Id);
        if (Request.Files.Count > 0)
        {
            HttpPostedFileBase objFiles = Request.Files[0];
            using (var binaryReader = new BinaryReader(objFiles.InputStream))
            {
                channel.GateImage = binaryReader.ReadBytes(objFiles.ContentLength);
            }
        }
        else
            channel.GateImage = old.GateImage;
        var cat = db.Category.Find(CatID);
        if (cat != null)
            channel.Category = cat;
        db.Entry(old).State = EntityState.Detached; // just added this line
        db.Entry(channel).State = EntityState.Modified;
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    return View(channel);
