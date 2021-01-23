    var products = ReadFromTheServiceMethd();
    Dictionary<int, BaseType> baseTypes = new Dictionary<int, BaseType>();
    foreach (var product in products)
    {
        if (!baseTypes.ContainsKey(product.NameIdFieldHere))
        {
            BaseType newBaseType = new BaseType();
            // set the other properties here...
            baseTypes[product.NameIdFieldHere] = newBaseType;
        }
        baseTypes[product.NameIdFieldHere].BaseProducts.Add(product);
    }
