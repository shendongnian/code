    public static bool IsObservableCollection(object candidate) {
        if (null == candidate) return false;
 
        var theType = candidate.GetType();
        bool itIs = theType.IsGenericType() && 
            !theType.IsGenericTypeDefinition()) &&
            (theType.GetGenericTypeDefinition() == typeof(ObservableCollection<>));
        return itIs;
    }
