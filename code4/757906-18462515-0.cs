    public static ITag GetByTagName(string tagName)
    {
        tagName = tagName.ToLower();
        if (!IsValidTagName(tagName))
            throw new ArgumentException(); // or return null
        return (ITag)Activator.CreateInstance(tags[tagName]);
    }
