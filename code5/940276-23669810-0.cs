    [AcceptVerbs(HttpVerbs.Get)]
    public ActionResult Image(int id)
    {
        byte[] byteArray = _imageRepository.GetImage(id);
        return new FileContentResult(byteArray, "image/jpeg");
    }
