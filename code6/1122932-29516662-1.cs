    public void FooToLinq()
    {
        Foo[] objs = { new Foo(), new Foo(), new Foo() };
        float value = 0.2f;
        var dictionary = objs.ToDictionary(x => x, x => value += 0.2f);
        foreach (KeyValuePair<Foo, float> pair in dictionary)
        {
            Console.WriteLine(pair);
        }
    }
