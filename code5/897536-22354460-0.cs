    public static string DisplayForWhenNotNull<T>(this HtmlHelper html, Func<T> obj, Func<T,object> prop)
    {
        var item = obj();
        if(item == null)
        {
            return null;
        }
        return prop(item);
    }
