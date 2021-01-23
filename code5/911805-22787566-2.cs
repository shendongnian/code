    public IEnumerable Remove(IEnumerable enumeration, object toRemove)
    {
        foreach (var e in enumeration)
        {
            if (!object.ReferenceEquals(e, toRemove))
            {
                yield return e;
            }
        }
    }
