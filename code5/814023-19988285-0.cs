    var properties = typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
        .Select(
            p =>
            new
                {
                    Name = p.Name,
                    Getter = (Func<T, object>) Delegate.CreateDelegate(typeof (Func<T, object>), p.GetGetMethod())
                })
        .ToList();
    return collection.Select(i => properties.ToDictionary(p => p.Name, p => p.Getter(i)));
