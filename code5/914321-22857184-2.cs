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
            else
                throw new ArgumentException("Sequence must contain at least two elements.", "items");
        }
        else
        {
            try
            {
                return items.Reverse().Skip(1).First();
            } catch (InvalidOperationException)
            {
                throw new ArgumentException("Sequence must contain at least two elements.", "items");
            }
        }
    }
