    protected static IDictionary<Guid,string> MyProperties =
        new Dictionary<Guid,string>();
    public static string GetMyProperty(Guid id) {
        return MyProperties[id];
    }
    public static void SetMyProperty(Guild id, string val) {
        MyProperties[id] = val;
    }
