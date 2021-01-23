    public T Get<T>(string id, Func<T> getItemCallback, Func<T, CustomType> conversion) where T : class
    {
        item = getItemCallback();
        if (item != null)
        {
            doSomeThing(item);
    
            CustomType newItem = conversion(item);
            doSomethingElse(new List<CustomType> { newItem });
        }
        return item;
    }
