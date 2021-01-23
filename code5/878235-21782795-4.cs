    public static Int32 GetTotalRecordsForTable<T>(Table<T> myTable)
       where T : class
    {
        DataContext dc = new DataContext ();
        return dc.GetTable<T>().Count();
    }
