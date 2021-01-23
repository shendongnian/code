    public CompareResult<T> GenericCompare<T, K>(CompareLogic compareLogic, List<T> OldObject, List<T> NewObject, Func<T, K> DelProperty, IEqualityComparer<K> keyComparer)
    {
        var ObjectAddedId = NewObjectId.Except(OldObjectId, keyComparer);
        var ObjectRemovedId = OldObjectId.Except(NewObjectId, keyComparer);
        ...
    }
