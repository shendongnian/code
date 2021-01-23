        public ActionResult DisplayPic()
        {
          Picture picture = new Picture();
          picture.PicPath = GetImagePath();  //Logic to get the image path as string
          return View(picture);
         }
