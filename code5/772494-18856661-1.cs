    static public IDictionary<EnumUnderlyingType, string> GetEnumList<EnumUnderlyingType>(Type enumType)
    {
        if (enumType != null)
            if (enumType.IsEnum && typeof(EnumUnderlyingType) == Enum.GetUnderlyingType(enumType))
            {
                IDictionary<EnumUnderlyingType, string> enumList = new Dictionary<EnumUnderlyingType, string>();
                foreach (object enumValue in Enum.GetValues(enumType))
                    enumList.Add((EnumUnderlyingType)enumValue, enumValue.ToString());
                return enumList;
            }
            else
                throw new ArgumentException("The provided type is either not an enumeration or the underlying type is not the same with the provided generic parameter.");
        else
            throw new ArgumentNullException("enumType");
    }
