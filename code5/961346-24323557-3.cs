    public Tag(Tag parentTag)
    {
        this.parentTag = parentTag;
    }
    private readonly Tag parentTag;
    public Tag ParentTag
    {
        get
        {
            return parentTag;
        }
    }
