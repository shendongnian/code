    public ActionResult viewImage(int Id)
    {
     Byte[] byteArray = MODEL.TABLE_NAME.Where(i =>colum_name == id).Select(i => i.FILE_DATA).Single();
     return File(byteArray, "image/png"); 
    }
