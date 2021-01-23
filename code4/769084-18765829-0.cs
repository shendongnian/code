    foreach (var enumValue in Enum.GetValues(typeof(Access.Level)))
    {
        var id = (int)enumValue;
        var val = enumValue.ToString();
        if(!context.Access.Any(e => e.AccessId == id))
            context.Access.Add(
                new Access { AccessId = id, Name = val }
            );
    }
    context.SaveChanges();
