    public ActionResult GetImage()
    {
        byte[] byteArray = MagicMethodToGetImageData();
        return new FileContentResult(byteArray, "image/jpeg");
    }
