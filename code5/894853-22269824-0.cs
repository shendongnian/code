    public static dynamic AddProperty<T>(this Object baseObject,string baseObjectPropertyName, string propertyName, T value)
    {
        var ob = new ExpandoObject() as IDictionary<string, Object>;
        ob.Add(baseObjectPropertyName, baseObject);
        ob.Add(propertyName, value);
        return ob;
    }
    var foo = new Foo();
    var ob = foo.AddProperty("FooObject","Hello", "World");
