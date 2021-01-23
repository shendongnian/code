    public ActionResult Gallery()
        {
            string folderpath = Server.MapPath("~/Content/Gallery/GalleryImages");
            List<String> currentimage = new Gallery().GetGalleryName(folderpath);
            //What will be the return type???/
            return View(currentimage);
        }
