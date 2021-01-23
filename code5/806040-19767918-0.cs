    // Might return null, better to use try catch
    public static Animals GetEnum(string val)
    {
        return (Animals)Enum.Parse(typeof(Animals), val, true);
    }
    
    public static string GetName(Animals an)
    {
        return Enum.GetName(typeof(Animals), an);
    }
