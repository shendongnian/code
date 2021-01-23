    public Tag ParentTag
    {
        …
        set
        {
            if (!IsOrIsAncestorOf(value))
            {
                parentTag = value;
            }
            else
            {
                throw new ArgumentException("ParentTag", "would cause a cycle");
            }
        }
    }
    private Tag parentTag;
    private bool IsOrIsAncestorOf(Tag other)
    {
        return this == other || IsOrIsAncestorOf(other.Parent));
        //     ^^^^^^^^^^^^^    ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        //          Is   …   Or    …    IsAncestorOf
    }
