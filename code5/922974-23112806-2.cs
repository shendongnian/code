    public static void Maybe<T>(this T obj, Action<T> action)
    {
        if (obj != null)
            action(obj);
    }
---
    strList.Maybe(list =>
        foreach(var str in list)
            Console.WriteLine(str));
