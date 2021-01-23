    public static bool IsAssignableFrom(this Type[] to, Type[] from)
    {
        if (to.Length != from.Length) return false;
        return to.Select((type, idx) => new { type, idx })
                 .All((x) => x.type.IsAssignableFrom(from[x.idx]));
    }
