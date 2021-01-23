    public ActionResult GetImage(string file)
    {
        var file12 = TagLib.File.Create(file);
        if (file12.Tag.Pictures.Length >= 1)
        {
            string fileName = Path.ChangeExtension(
                Path.GetFileName(file), ".jpg");
            return base.File(
                (byte[])(file12.Tag.Pictures[0].Data.Data),
                "image/jpg", fileName);
        }
    
        // You have to handle this case
        return null;
    }
