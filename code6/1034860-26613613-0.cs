    ICollection<SomeType> SomeProperty { get; set; }
    // good
    var property = SomeProperty; // capture
    var a = property[1] + ...
    // not so good
    for(int i = 0; i < SomeProperty.Count; i++) // Count may be taken from new instance
    {
        var a = SomeProperty[i]; // really bad
        ...
    }
    // bad
    if(SomeProperty != null) ...
