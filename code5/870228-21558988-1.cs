    public static void Foo(CacheAction action)
    {
        if (action == ActionsTypeA.SomthingFromACache) { }
        else if (action == ActionsTypeA.SomethingElseFromACache) { }
        else if (action == ActionsTypeB.SomthingFromBCache) { }
        else if (action == ActionsTypeB.SomethingElseFromBCache) { }
        else throw new ArgumentException("Invalid action provided");
    }
