    // make IEnumerable<YourType>
    var itemType = items[0].GetType();
    var castDef = typeof(Enumerable).GetMethod("Cast");
    var cast = castDef.MakeGenericMethod(itemType);
    var enumerable = cast.Invoke(null, new[] { items });
    // call GenericExport<YourType>
    var methodDef = typeof(Program).GetMethod("GenericExport", BindingFlags.Instance | BindingFlags.NonPublic);
    var method = methodDef.MakeGenericMethod(itemType);
    method.Invoke(this, new[] { enumerable });
