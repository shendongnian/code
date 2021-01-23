    // And an ISet<T> of existing items
    var types = new HashSet<string>();
    foreach (string typeToAdd in Addresses.Select(aa => aa.AddressType))
    {
        // you can test if typeToAdd is really a new item
        // through the return value of ISet<T>.Add:
        if (!types.Add(typeToAdd))
        {
            // ISet<T>.Add returned false, typeToAdd already exists
        }
    }
