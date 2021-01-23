    SomeMagicMethod(object obj, params string[] names)
    {
        foreach(var name in names) {
           object val = obj.GetType().GetProperty(name).GetValue(obj);
           // ...
        }
    }
    //...
    SomeMagicMethod(testObj, "StringHere", "ANumber");
