    // Here I'm using the IList<T> interface
    IList<string> list = new List<string> { "foo1", "foo2", "bar1", "bar2" };
    // Begin from last, it will be faster to remove
    for (int i = list.Count - 1; i >= 0; i--)
    {
        // Your condition
        if (list[i].StartsWith("foo"))
        {
            list.RemoveAt(i);
        }
    }
