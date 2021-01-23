    foreach(int i in Enum.GetValues(typeof(stuff)))
    {
        String name = Enum.GetName(typeof(stuff), i);
        NewObject thing = new NewObject
        {
            Name = name,
            Number = i
        };
    }
