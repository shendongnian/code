    public static Int32 GetTotalRecordsForTable<T>()
       where T : class
    {
        DataContext dc = new DataContext ();
        return dc.GetTable<T>().Count();
    }
    // call these methods like:
    GetTotalRecordsForTable(myTable); // T as Table1 is inferred
    GetTotalRecordsForTable<Table1>(); // T as Table1 is explicitly specified
