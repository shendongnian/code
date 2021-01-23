    foreach (String s in newBlog.RawTags)
    { 
        // First check to see if the tag already exists
        Tag check = Db.Tags.Where(m => m.Name == s).FirstOrDefault();
        if (check != null)
        {
            check.RefCount++;
            check.BlogEntries.Add(newBlog); // MODIFICATION
            newBlog.BlogTags.Add(check);
            Db.Tags.Attach(check);
            Db.Entry(check).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }
        else
        {
            // Create a new tag
            Tag newTag = new Tag();
            newTag.Name = s;
            newTag.RefCount = 1;
            newTag.BlogEntries = new List<BlogEntry>(); // MODIFICATION
            newTag.BlogEntries.Add(newBlog); // MODIFICATION
            newBlog.BlogTags.Add(newTag);
            Db.Tags.Add(newTag);
        }
    }
