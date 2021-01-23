    public static IQueryable<MyUserDto> WhereForenameIs(this IQueryable<MyUserDto> source, string name)
    {
        return
            source
            .Where(u => u.Forename = name);
    }
