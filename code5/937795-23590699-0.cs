    public FileContentResult getImg(int id)
    {
        byte[] byteArray = DbContext.Persons.Find(id).Image;
        if (byteArray != null)
        {
            return new FileContentResult(byteArray, "image/jpeg");
        }
        else
        {
            return null;
        }
    }
