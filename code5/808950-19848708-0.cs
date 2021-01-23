    var attributeType = entryAssembly.GetTypes()
                                        .FirstOrDefault(t => t.Name == "SomeAttribute");
    if (attributeType != null)
    {
        //the assembly contains the type
    }
    else
    {
        //type was not found
    }
