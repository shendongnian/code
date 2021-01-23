    if (entity.Tags.All(t => t.Label != tag))
    {
        var tagEntity = _context.Tags.FirstOrDefault(t => t.Label == tag);
        
        if(tagEntity == null)
            tagEntity = _context.Tags.Add(new Tag {Label = tag});
        entity.Tags.Add(tagEntity);
    }
