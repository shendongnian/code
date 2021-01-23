    public List<object> convertObjectBackToList(object Input)
    {
        if(Input is IEnumerable)
            return ((IEnumerable)Input).Cast<Object>().ToList();
        return new List<Object>() { Input };
    }
