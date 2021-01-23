    public static void Iterate(IEnumerable itemList)
    {
        var enumerator = itemList.GetEnumerator();
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }
    }
