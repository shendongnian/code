    Contact myContact = ...;
    typeof(ContactKeys)
        .GetFields(BindingFlags.Public | BindingFlags.Static)
        .ToDictionary(f => (int)f.GetValue(null),
                      f => typeof(Contact).GetProperty(f.Name).GetValue(myContact));
