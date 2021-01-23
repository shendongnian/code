    private List<Bar> _Bars = new List<Bar>();
    public ReadOnlyCollection<Bar> Bars
    {
        get { return _Bars.AsReadOnly(); }
    }
    public void OrderBy(Func<Bar, bool> src)
    {
        _Bars = _Bars.OrderByDescending(src);
    }
    ...
    var foo = new Foo();
    foo.OrderBy(x => x.Volume);
