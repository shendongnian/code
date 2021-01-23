    public IEnumerable<string> GetSelectedIds(){
       if (_kids == null)
            return null;
       
       return GetSelectedIds2();
    }
    
    private IEnumerable<string> GetSelectedIds2()
    {
        foreach (var current in _kids.Nodes)
            yield return current;
    }
