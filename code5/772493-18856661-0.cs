    static public IDictionary<float, string> GetEnumList(Type enumType)
    {
        if (enumType != null)
            if (enumType.IsEnum)
            {
                IDictionary<float, string> enumList = new Dictionary<float, string>();
                foreach (object enumValue in Enum.GetValues(enumType))
                    enumList.Add(Convert.ToSingle(enumValue), Convert.ToString(enumValue));
                return enumList;
            }
            else
                throw new ArgumentException("The provided type is not an enumeration.");
        else
            throw new ArgumentNullException("enumType");
    }
