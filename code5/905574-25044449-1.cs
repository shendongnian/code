    public ActionResult Create(ArtWork artwork, HttpPostedFileBase image) { 
      if (ModelState.IsValid) { 
        if (image != null) { //attach the uploaded image to the object before saving to Database 
          artwork.ImageMimeType = image.ContentLength; 
          artwork.ImageData = new byte[image.ContentLength]; 
          image.InputStream.Read(artwork.ImageData, 0, image.ContentLength); //Save image to file 
          var filename = image.FileName; 
          var filePathOriginal = Server.MapPath("/Content/Uploads/Originals"); 
          var filePathThumbnail = Server.MapPath("/Content/Uploads/Thumbnails"); 
          string savedFileName = Path.Combine(filePathOriginal, filename); 
          image.SaveAs(savedFileName); //Read image back from file and create thumbnail from it 
          var imageFile = Path.Combine(Server.MapPath("~/Content/Uploads/Originals"), filename); 
    
          using (var srcImage = Image.FromFile(imageFile)) 
          using (var newImage = new Bitmap(100, 100)) 
          using (var graphics = Graphics.FromImage(newImage)) 
          using (var stream = new MemoryStream()) { 
            graphics.SmoothingMode = SmoothingMode.AntiAlias; 
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic; 
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality; 
            graphics.DrawImage(srcImage, new Rectangle(0, 0, 100, 100)); 
            newImage.Save(stream, ImageFormat.Png); 
            var thumbNew = File(stream.ToArray(), "image/png"); 
            artwork.ArtworkThumbnail = thumbNew.FileContents; 
          } 
        } 
    
        //Save model object to database 
        db.ArtWorks.Add(artwork); 
        db.SaveChanges(); 
        return RedirectToAction("Index"); 
      } 
      return View(artwork); 
    }
