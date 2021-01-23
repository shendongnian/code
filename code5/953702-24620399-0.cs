        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            // TODO: your validation goes here, 
            // eg: file != null && file.ContentType.StartsWith("image/") etc...
            var imageUrl = _myAmazonWrapper.UploadImage(file.InputStream);
            return Json(imageUrl);
        }
