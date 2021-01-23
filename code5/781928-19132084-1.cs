    public static T Clone<T>(this T item)
        where T : SimpleEntityBase
    {
        return (T)item.EntityClone();
    }
