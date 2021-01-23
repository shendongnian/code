    public static string getLogicalValue(byte numericalValue)
    {
        Type type = numericalValue.GetType();
        var name = Enum.GetName(typeof(MessageTypeEnum), numericalValue);
        if (numericalValue < 0x02)
            return name;
        else
            return MessageTypeEnum.identify.ToString();
    }
