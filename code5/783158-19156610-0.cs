            var task = Request.Content.ReadAsByteArrayAsync();
            var bytes = task.Result;
            Image img = new Image();
            img.Id = Guid.NewGuid();
            img.ImageData = bytes;
            db.Images.Add(img);
            db.SaveChanges();
