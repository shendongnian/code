    public List<Tag> CreateOrRetrieveTags(List<Tag> tags)
    {   
        var newTags = tags.Where(t => t.Id == 0);
        foreach (string newTag in newTags)
        {
            _context.Tags.Add(newTag);
        }
        _context.SaveChanges();
    
        return from t in _context.Tags
            where tags.Any(t.Text == t.Text)
            select t;
    }
