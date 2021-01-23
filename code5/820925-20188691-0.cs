    [NotMapped]
    public MvcHtmlString PageBody { get; set; }
    public string Body
    {
        get { return PageBody.ToHtmlString(); }
        set { PageBody = new MvcHtmlString(value); }
    }
