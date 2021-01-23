    public ActionResult Gallery()
    {
      List<String> galleryList = new List<String>();
      string folderpath = Server.MapPath("~/Content/Gallery/GalleryImages");
      string[] currentimage = new Gallery().GetGalleryName(folderpath);
      foreach (var folder in currentimage) {
        galleryList.Add(folder);
      }
    return View(galleryList);
    }
