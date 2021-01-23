    foreach (var x in attrs)
    {
        var attributeType = x.GetType();
        if (attributeType.FullName == "ClassLibrary1.IDAttribute") // also check for attributeType.Assembly == loaded assembly, if needed 
        {
            dynamic idAttribute = x;
            int id = idAttribute.ID;
        }
    }
