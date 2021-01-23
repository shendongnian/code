    public static System.Web.Mvc.SelectList ToSelectList<T>(this Enum TEnum) where T : struct, IComparable, IFormattable, IConvertible
    {
    
        return new SelectList( Enum.GetValues(typeof(T)).OfType<T>()
                                                    .Select(x =>
                                                       new SelectListItem
                                                       {
                                                           Text = x.ToString(),
                                                           Value = ((T)x).ToString()
                                                       }));
    }
