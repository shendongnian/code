    Photo p = new Photo();
    Tag tag1 = new Tag() { ... };
    Tag tag2 = new Tag() { ... };
    p.Tags.Add(new Tag_Photo_XREF { Tag = tag1 };
    p.Tags.Add(new Tag_Photo_XREF { Tag = tag2 };
    
    context.Photos.Add(p);
    context.SaveChanges();
