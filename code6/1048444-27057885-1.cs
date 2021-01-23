    public static IEnumerable<T> Concatenate<T>(params IEnumerable<T>[] List)
    {
        foreach (var listelement in List)
        {
            foreach (var subelement in listelement)
            {
                yield return subelement;
            }
        }
    }
