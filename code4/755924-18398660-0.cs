    var dict = new Dictionary<string, Func<UnitDescriptor>>();
    dict.Add(UnitCode.DEG_C, () => new UnitDescriptorDegC());
    dict.Add(UnitCode.DEG_F, () => new UnitDescriptorDegF());
    // ...
    private static UnitDescriptor createUnitDescriptor(string code)
    {
        Func<UnitDescriptor> value;
        if (dict.TryGetValue(code, out value))
        {
            return value();
        }
        throw new SystemException(string.Format("unknown code: {0}", code);
    }
