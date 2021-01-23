    public new bool Add(T item) 
    {
        bool answer = base.Add(item);
        if(Added != null)
        {
            Added();
        }
        return answer;
    }
