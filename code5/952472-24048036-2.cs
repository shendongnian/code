    [HttpPost]
    public ActionResult Action(ViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Use your file here
            using (MemoryStream memoryStream = new MemoryStream())
            {
                model.File.InputStream.CopyTo(memoryStream);
            }
            var uploadDir = "~/uploads"
            var imagePath = Path.Combine(Server.MapPath(uploadDir), model.ImageUpload.FileName);
            var imageUrl = Path.Combine(uploadDir, model.ImageUpload.FileName);
            model.ImageUpload.SaveAs(imagePath);
            model.ImagePath= imageUrl;
        }
    }
