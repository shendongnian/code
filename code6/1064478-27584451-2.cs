    Type listType = enumerable.GetType();
    IList newList = Activator.CreateInstance(listType) as IList;
    if (newList != null)
    {
        foreach (var item in enumerable)
        {
            newList.Add(item);
        }
    }
