    public static void Use<T>(T item, Action<T> action)
    {
        action(item);
    }
---
    Use(from l in listTest
        select new
        {
            _string = l,
            Lenght = l.Length
        },
        query => Console.WriteLine(string.Join("\n", query)));
