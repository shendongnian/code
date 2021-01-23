    public static IEnumerable<T> Concartenate<T>(params IEnumerable<T>[] List)
    {
        var Temp = List.First();
        for (int i = 1; i < List.Count(); i++)
        {
            Temp = Enumerable.Concat(Temp, List.ElementAt(i));
        }
        return Temp;
    }
