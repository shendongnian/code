        [HttpPost]
        public JsonResult Upload(HttpPostedFileBase file)
        {
            IMedia mimage;
            // Create the media item
            mimage = _mediaService.CreateMedia(file.FileName, <parentId>, Constants.Conventions.MediaTypes.Image);
            mimage.SetValue(Constants.Conventions.Media.File, file);
            _mediaService.Save(mimage);  
            return Json(new { success = true});
        }
