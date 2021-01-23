    private void Example()
    {
        var things = new Foo<Thing>(_Repository.GetObjects<Thing>());
                
        bool x = things.HasBeenIterated;//is false
        foreach (var thing in things)
        {
            x = things.HasBeenIterated;//is true
        }
    }
