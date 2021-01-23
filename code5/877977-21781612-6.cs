    // original class:
    virtual object[] attributeReader(PropertyInfo prop)
    {
        return prop.GetCustomAttributes(true);
    }
    // derived class:
    object[] AttributesOverrides {get;set;}
    override object[] attributeReader(PropertyInfo prop)
    {
        if(prop.Name = "ShoeSize") return AttributesOverrides; // return what I say!
        return base.attributeReader(prop);
    }
    // your test setup
    var t = ... // that DERIVED object
    t.AttributesOverrides = new [] { ... } ; // attributes to use
