    [SitecoreUrl]
    public Lazy<string> LazyUrl { private get; set; }
    
    [SitecoreIgnore]
    public virtual string Url
    {
        get
        {
            return this.LazyUrl.Value;
        }
    }
