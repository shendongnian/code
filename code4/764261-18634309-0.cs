    public static bool Compare(this object o1, object o2)
    {
        if (o1 is Array && o2 is Array)
        {
            // special array handling
            IEnumerable<object> source = (o1 as Array).A();
            IEnumerable<object> test = (o2 as Array).A();
            // this fails now, because source and test are null.
            return source.SequenceEqual(test);
        }
        else
        {
            return o1.Equals(o2);
        }
    }
    public static IEnumerable<object> A(this Array a)
    {
        foreach (var item in a)
        {
            yield return item;
        }
    }
