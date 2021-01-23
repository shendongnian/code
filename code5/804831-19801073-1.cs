    public interface IPerson
    {
        // extended property(s)
        string Name { get; set; }
        // base class to extend
        Person Person { get; set; }
    }
