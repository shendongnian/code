    var content = db.Contents.Select(s => new
    {
        s.ID,
        s.Title,
        s.Image,
        s.Contents,
        s.Description
      });
      List<ImageUpload> imageModel = content.Select(item => new ImageUpload()
      {
            ID = item.ID,
            Title = item.Title,
            Image = item.Image,
            Description = item.Description,
            Contents = item.Contents
        }).ToList();
       return View(imageModel);
