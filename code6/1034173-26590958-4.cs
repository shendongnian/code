    private List<Bar> _Bars = new List<Bar>;
    public void OrderBy(Func<Bar, bool> src)
    {
        _Bars = _Bars.OrderByDescending(src).ToList();
    }
