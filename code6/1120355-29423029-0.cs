    public new bool Add(T item) 
    {
        bool answer = base.Add(item);
        Added?(); //or Added?.Invoke()
        return answer;
    }
