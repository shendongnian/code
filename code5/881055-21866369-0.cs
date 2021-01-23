    public static List<T> SomeMethod<T>(this IEnumerable<T> list, int id)  where T : SomeClass
    {
        List<T> result = new List<T>();
        foreach (T something in list)
        {
            if (something.SomeProperty.SomeList.Contains(id))
            {
                result.Add(something);
            }
        }
        return result;
    }
