    public T Get<T>(string id, Func<T> getItemCallback, Func<T, List<CustomType>> conversion) where T : class
    {
        item = getItemCallback();
        if (item != null)
        {
            doSomeThing(item);
    
            if (conversion != null)
                doSomethingElse(conversion(item));
        }
        return item;
    }
