    public interface IPerson
    {
        // extended property(s)
        string Name { get; set; }
        // base class to extend - tho we should try to overcome using this
        Person Person { get; set; }
    }
