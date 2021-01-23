    public bool TrySetBlogId(string newId)
    {
        Guid id;
        var stringIsGuid = Guid.TryParse(newId, out id);
        
        if (stringIsGuid)
        {
            BlogId = id;
        }
        return stringIsGuid;
    }
