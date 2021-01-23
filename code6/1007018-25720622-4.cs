    TElement someObject = list.First();
    if (typeof(TElement) == typeof(MyClass))
    {
       var casted = (MyClass)someObject;
       //some Code
    }
    
    if (typeof(TElement) == typeof(MyClass2))
    {
       var casted = (MyClass2)someObject;
       //some Code
    }
    
    // and so on.
