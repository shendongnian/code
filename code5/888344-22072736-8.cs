    public static T CopyTo<T>(object source)
        where T : new()
    {
        if (source == null) throw new ArgumentException("surce is null", "source");
        T target = new T();
        source.GetType()
              .GetProperties()
              .Join(target.GetType().GetProperties()
                    , s => s.Name
                    , t => t.Name
                    , (s, t) => new
                        {
                            source = s,
                            target = t
                        })
              .AsParallel()
              .Where(inCommon => inCommon.source.PropertyType == inCommon.target.PropertyType
                                 && inCommon.source.CanRead && inCommon.target.CanWrite)
              .ForAll(inCommon => inCommon.target.SetValue(target, inCommon.source.GetValue(source, null), null));
        return target;
    }
