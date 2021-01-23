    public static void Foo(CacheAction action)
    {
        if (action == CacheAction.TypeA.SomthingFromACache) { }
        else if (action == CacheAction.TypeA.SomethingElseFromACache) { }
        else if (action == CacheAction.TypeB.SomthingFromBCache) { }
        else if (action == CacheAction.TypeB.SomethingElseFromBCache) { }
        //this will only be hit by null unless you omit an option above
        else throw new ArgumentException("Invalid action provided");
    }
