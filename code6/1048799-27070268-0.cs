    // Save changes to database
    var entry = db.Entry(imageFile);
    entry.Property(i => i.ImageUrl).IsModified = true;
    entry.Property(i => i.FileName).IsModified = true;
    db.SaveChanges();
