    public static Action<IComponentMapper<Profile>> Mapping()
    {
        return c =>
        {
           ...
           c.Parent(p => p.User);               
        }
    }
