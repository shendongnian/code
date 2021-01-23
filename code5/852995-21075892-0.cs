    public IEnumerable<T> UseHelper<T> (IHelper<T> helper)
    {
         
    }
    delegate IEnumerable<object> UseHelperDelegate(IHelper helper)
    Dictionary<Type, UseHelperDelegate> helpersMap;
    
    helpersMap.Add(typeof(int), UseHelper<int>); // Add other is you want
    public IEnmerable<object> UseHelperWithMap(IHelper helper)
    {
        Type helperType = helper.GetType();
        IEnumerable<object> retValue;
        if (helpersMap.Contains(helperType )
        {
             retValue = helpersMap[helperType](helper);
        }
        else // if the type is not maped use DLR
        {
             dynamic dynamicHelper = helper;
             retValue = UseHelper(dynamicHelper)
             // I wonder if this can actually be added to the map here
             // to improve performance when the same type is called again.
        }
    }
