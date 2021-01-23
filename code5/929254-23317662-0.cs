    public static TItem GetMinItem<TItem>(this IEnumerable<TItem> items) where TItem : IComparable<TItem>
    {
        TItem minItem = default(TItem);
         bool isFirstItem = true;
            foreach (var item in items)
            {
                if (isFirstItem)
                {
                    minItem = item;
                    isFirstItem = false;
                }
            else
            {
                if (item.CompareTo(minItem) < 0)
                {
                    minItem = item;
                }
            }
        }
        return minItem;
    }
