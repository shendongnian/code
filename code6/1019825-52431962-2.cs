        ImageUpload.Image = ConvertToBytes(file);
        var Content = new Content
        {
            Title = imageupload.Title,
            Description = imageupload.Description,
            Contents = imageupload.Contents,
            Image = imageupload.Image
        };
        db.Contents.Add(Content);
        int i = db.SaveChanges();
        if (i == 1)
        {
            return 1;
        }
        else
        {
            return 0;
        }
