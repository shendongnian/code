    public DtoClass(LegacyClass legacyClass)
    {
        if (!legacyClass.PropA && !legacyClass.PropB && !legacyClass.PropC)
        {
            throw new ArgumentException();
        }
        FlagEnum =  ((legacyClass.PropA) ? FlagEnum.EnumValue1 : FlagEnum)
            | ((legacyClass.PropB) ? FlagEnum.EnumValue2 : FlagEnum)
            | ((legacyClass.PropC) ? FlagEnum.EnumValue3 : FlagEnum);
    }
