    public static object AddProperty<T>(this Object baseObject,string baseObjectPropertyName, string propertyName, T value)
    {
        IDictionary<string, object> ob;
        if (baseObject is IDictionary<string, object>)
        {
            ob = baseObject as IDictionary<string, Object>;
        }
        else
        {
            ob = new ExpandoObject() as IDictionary<string, Object>;
            ob.Add(baseObjectPropertyName, baseObject);
        }
        ob.Add(propertyName, value);
        return ob;
    }
    var foo = new Foo();
    var goingTobeIgnored = string.Empty;
    dynamic ob = foo.AddProperty("FooObject","Hello", "World")
                .AddProperty(goingTobeIgnored, "AnotherHello", "AnotherWorld");
