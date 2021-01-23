    Contact myContact = ...;
    typeof(ContactKeys)
        .GetProperties(BindingFlags.Public)
        .ToDictionary(k => (int)k.GetValue(null),
                      k => typeof(Contact).GetProperty(k.Name).GetValue(myContact));
