    if (specField != null)
    {
        if (!AddSystemType(specField, layout))
        {
            if (!AddEnumType(specField, layout))
            {
                AddUserType(specField, layout);
            }
        }
    }
