        public void Upload(HttpPostedFileBase fichier, string filename, int iparentId)
        {
            IMedia mimage;
            // Create the media item
            mimage = _mediaService.CreateMedia(filename, iparentId, Constants.Conventions.MediaTypes.Image);
            mimage.SetValue(Constants.Conventions.Media.File, fichier);
            _mediaService.Save(mimage);           
        }
