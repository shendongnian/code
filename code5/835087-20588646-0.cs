    public static IEnumerable<Object> Pluck<Object>(this IEnumerable<Object> source, string propName)
    {
        return source
            .Select(x => new {
                obj: x
                prop: x.GetType().GetProperty(propName)
            })
            .Where(x => x.prop != null)
            .Select(x => x.prop.GetValue(x.obj));
    };
