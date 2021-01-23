    public FileContentResult getImage(int id)
    {
        byte[] imgBytes = System.IO.File.ReadAllBytes(path);
        if (imgBytes!= null)
        {
            return new FileContentResult(imgBytes, "image/jpeg");
        }
        else
        {
            return null;
        }
    }
