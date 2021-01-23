    // Removes all specified attributes and children of the current node.
    // Default attributes are not removed.
    public override void RemoveAll()
    {
        base.RemoveAll();
        this.RemoveAllAttributes();
    }
