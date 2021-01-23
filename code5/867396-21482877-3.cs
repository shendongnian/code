    public static void Foo(Guid? guid)
    {
        if (guid.HasValue)
        {
            // ...
        }
        else
        {
            Guid g = guid.Value;
            // ...
        }
    }
