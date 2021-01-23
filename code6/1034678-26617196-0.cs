     using (var scope = db.GetTransaction())
     {
         db.Update(item);
         foreach (var pictureLink in item.PictureLinks)
         {
             db.Update(pictureLink);
         }
         scope.Complete();
      }
