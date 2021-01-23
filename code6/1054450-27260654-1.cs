    internal static TCol ThrowIfNullEmptyOrContainsNull<TCol, TEl>(TCol collection, string name)
        where T1 : ICollection<TEl>
    {
      if (ReferenceEquals(value, null))
          throw new ArgumentNullException(name);
      if (value.Count == 0)
        throw new ArgumentException("Empty collection not allowed", name);
      if(default(TEl) == null)
        foreach(var item in collection)
          if(item == null)
            throw new ArgumentException("Collection cannot contain null elements", name);
      return value;
    }
