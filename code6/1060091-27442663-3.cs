     [HttpPost]
     public JsonResult GetImagePreview()
     {
         try
         {
         if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
         {
             var img = System.Web.HttpContext.Current.Request.Files["img"];
             var ms = new MemoryStream();
             var logo = Image.FromStream(img.InputStream);
             logo = FixedSize(logo, 150, 150);
             logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    
             return Json(new {base64imgage = Convert.ToBase64String(ms.ToArray())});
         }
         return Json("ko");
       }
       catch (Exception)
       {
          return Json("ko");
       }
     }
