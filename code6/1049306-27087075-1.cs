    private static readonly Lazy<Hashtable> _ht = new Lazy<Hashtable>(() => InitializeTable());
    internal static Hashtable GetHT() { return _ht.Value; }
    private static Hashtable InitializeTable()
    {
        Hashtable table = new Hashtable();
        LoadHt(table);
        return table;
    }
