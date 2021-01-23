    public ActionResult Lager()
    {
        var model = _db.Items.Where(i => i.Status == 0).Select(i => new { Picture = i.Pictures.FirstOrDefault(), Item = i} ).Select(i => new {
                  ItemID = i.Item.ItemID,
                  Name =  i.Item.Name,
                  Status = i.Item.Status,
                  PictureFilename = i.Picture != null ? i.Picture.Filename : null,
                  PictureFilepath = i.Picture != null ? i.Picture.Filepath : null
             }).ToList();
        return View(model);
    }
