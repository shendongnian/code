    public static List<String> GetLangIDList(IEnumerable<ILocalized> list)
    {
        //I want all the ID of the lang where car is translated for:
        var somethin = list.Select(m => m.LCID_SpracheID.ToString()).ToList();
        return somethin;
    }
