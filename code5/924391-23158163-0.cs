    public void DoStuff(Query query)
    {
        // The query only ever returns bananas OR Apples. Never both.
        var items = repository.GetItems<BaseClass>(query);
    
        foreach (var item in items.OfType<Banana>())
        {
            // Code to set Length if Banana
        }
    }
