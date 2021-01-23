    public static string MyJoin(this IEnumerable items)
    {
	    if (items is IEnumerable<string>) return string.Join(Environment.NewLine, (IEnumerable<string>)items);
    	if (items is IEnumerable<IEnumerable>) return items.Cast<IEnumerable>().Select(x => x.MyJoin())).MyJoin();
        throw new InvalidOperationException("Type is not a (nested) enumarable of strings");
    }
