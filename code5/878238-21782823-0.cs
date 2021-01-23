    public static Int32 GetTotalRecordsForTable<TTable>()
    {
        DataContext dc = new DataContext ();
        return dc.GetTable<TTable>().Count();
    }
