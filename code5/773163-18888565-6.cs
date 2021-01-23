    if (!objectKeys.TryGetValue(value, out index)) index = -1;
    ...
    if (!(existing = index >= 0))
    {
        index = list.Add(value); // <=== creates a new identity
        ...
        objectKeys.Add(value, index); // <=== adds to the dictionary
    }
