    public void Add(TValue item) 
    {
        if(!_Container.Select(p => p.Value).Contains(item, _equalityComparer) 
            _Container.Add(Indexed.Create(_Index++, item)); 
    }
