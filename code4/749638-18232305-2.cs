    public static void InitAll<T>(this T[] array, Func<int, T> initializer)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = initializer.Invoke(i);
        }
    }
    Foo[] foos = new Foo[5];
    foos.InitAll(_ => new Foo());
    //or
    foos.InitAll(i => new Foo(i));
