    public static T SecondLast<T>(this IEnumerable<T> items)
    {
        if (items == null) throw new ArgumentNullException("items");
        IList<T> list = items as IList<T>;
        if (list != null)
        {
            int count = list.Count;
            if (count > 1)
            {
                return list[count - 2];
            }
        }
        return items.Reverse().Skip(1).First();
    }
