    if(tag!=null)
    {
      photo.Tags.Add(new Tag() { TagName = tagName });
    }
    else
    {
      if(photo.Tags.All(t=>t.Id!=tag.Id))
         photo.Tags.Add(tag);
    }
