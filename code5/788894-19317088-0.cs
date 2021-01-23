    // Link to component of type B through a property.
    // The name doesn't matter.
    [ComponentLink]
    B B { get; set; }
    // Called when components are added or removed.
    // The parameter type acts as a filter.
    [NotifyComponentLinked]
    void Added(object o)
    { Console.WriteLine(this.GetType().Name + " linked to " + o.GetType().Name + "."); }
    [NotifyComponentUnlinked]
    void Removed(object o)
    { Console.WriteLine(this.GetType().Name + " unlinked from " + o.GetType().Name + "."); }
    // Attaches to events in compenents of type D and E.
    // Rewriting this with Lambda Expressions may be possible,
    // but probably would be less concise due to lack of generic attributes.
    //
    // It should be possible to validate them automatically somehow, though.
    [EventLink(typeof(D), "NumberEvent")]
    [EventLink(typeof(E), "NumberEvent")]
    void NumberEventHandler(int number)
    { Console.WriteLine("Number received by F: " + number); }
