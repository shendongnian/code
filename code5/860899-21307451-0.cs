    public static Dictionary<string, string> EnumToDictionary(this Enum @enum)
    {
        var type = @enum.GetType();
        return Enum.GetValues(type).Cast<string>().ToDictionary(e => e, e => Enum.GetName(type, e));
    }
