    public static IQueryable<TItem> ApplyFilter<TItem, TEnum>(IQueryable<TItem> items, 
                  IEnumerable<TEnum> enumValues, Expression<Func<TItem,TEnum>> enumField)
    {
         return items.Where(i => enumValues.Contains(enumField(i)));
    }
