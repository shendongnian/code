    public static Int32 GetTotalRecordsForTable<T>(Table<T> myTable)
    {
        DataContext dc = new DataContext ();
        return dc.GetTable<T>().Count();
    }
