    public enum ObjectType
    {
        TreeA,
        TreeB,
        TreeC,
    }
    Dictionary<ObjectType, Type> DarkForestObjectTypes = new Dictionary<ObjectType, Type>()
    {
        { ObjectType.TreeA, typeof(DarkForestTreeA) },
        { ObjectType.TreeB, typeof(DarkForestTreeB) }
        ...
    }
