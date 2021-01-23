    private readonly IList<Page> _page;
    public User(IEnumerable<Page> page)
    {
        _page = new List<Page>(page);
    }
    public IList<Page> Page
    {
        get { return _page; }
    }
