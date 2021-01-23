    public static T FetchAndRemoveFirst<T>(this LinkedList<T> list)
    {
        T first = list.First.Value;
        list.RemoveFirst();
        return first;
    }
    public static T FetchAndRemoveLast<T>(this LinkedList<T> list)
    {
        T last = list.Last.Value;
        list.RemoveLast();
        return last;
    }
