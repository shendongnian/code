        public Image AddImage(HttpPostedFileBase imageToSave, Image modelImage)
        {
            Image img = new Image();
            img = modelImage;
            img.ImageUrl=SaveUploadedFile(imageToSave, img.Id);
            unitofWork.ImagesRepository.Insert(img);
            unitOfWork.SaveChanges(); // you didn't save the change.
            return img;
        }
