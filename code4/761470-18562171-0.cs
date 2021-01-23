    public ClassName(IEnumerable<OtherClassName> models)
        : this(models.ToList())
    {
    }
    private ClassName(List<OtherClassName> models)
        : base(models)
    {
        _models.AddRange(models);
    }
