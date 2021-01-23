    var test = (new[]
    {
        new
        {
            Property1 = "10",
            Property2 = "10",
            Property3 = 1
        }
    }
    .Select("New(Property1, Property2)"))
    .ToAnonymousList();
