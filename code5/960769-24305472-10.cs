    public void Test(Type1 param1, Type2 param2)
    {
        Contracts.Requires((param1 == null && param2 != null) || (param1 != null && param2 == null),       "Only one parameter is needed");
        // ...
    }
