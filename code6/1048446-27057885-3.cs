    public static IEnumerable<T> Concatenate<T>(params IEnumerable<T>[] List)
    {
        foreach (IEnumerable<T> element in List)
        {
            foreach (T subelement in element)
            {
                yield return subelement;
            }
        }
    }
