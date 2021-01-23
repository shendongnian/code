    ISortable<TEnum> where TEnum : struct, IComparable
    {
        TEnum Sort { get; }
    }
    
    public static IHtmlString SortablePersonHeader<TEnum>(this AjaxHelper helper, string headerTitle, TEnum sort, ISortable<TEnum> searchCriteria)
        where TEnum : struct, IComparable
    {
        if(! typeof(TEnum).IsEnum) throw new ArgumentException("Requires enum type");
        if(sort.Equals(searchCriteria.Sort))
        {
        }
    }
