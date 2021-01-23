    private List<Items> _source;
    public List<Items> PopulatelstStatus()
    {
        if(_source == null)
        {
            _source = new List<Items>();
            _source.Add(new Items() { Name = "Booked" });
            _source.Add(new Items() { Name = "Confirmed" });
            _source.Add(new Items() { Name = "Completed" });
            _source.Add(new Items() { Name = "Cancelled" });
        }
        return _source;
    }
