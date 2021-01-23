    public static void Foo(Guid? guid)
    {
        if (guid.HasValue)
        {
            Guid g = guid.Value;
            // ...
        }
        else
        {
            // ...
        }
    }
