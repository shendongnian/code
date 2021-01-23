    private static readonly Hashtable _ht = InitializeTable();
    internal static Hashtable GetHT() { return _ht; }
    private static Hashtable InitializeTable()
    {
        Hashtable table = new Hashtable();
        LoadHt(table);
        return table;
    }
