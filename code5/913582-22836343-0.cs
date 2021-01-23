    // Navigation Property
    public Child Child
    {
        get { return this.i_Child ?? (this.i_Child = new Child()); }
        set { this.i_Child = value; }
    }
    // Backing Field
    protected internal virtual ContactDetails i_ContactDetails { get; private set; }
