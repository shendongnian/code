     using (var db = new YourContext())
     {
        //Create the photo
         var photo = new Photo() { OwnerId = 1, ImageName = "Picture", Path = @"E:\Pictures" };
         //Add the tags
         photo.Tags.Add(new Tag() { TagName = "Family" });
         photo.Tags.Add(new Tag() { TagName = "Friend" });
         db.Photos.Add(photo);
         db.SaveChanges();
     }
