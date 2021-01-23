    public static void Iterate(dynamic itemList)
    {
        var enumerator = ((IEnumerable)itemList).GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
