    public static Int32 GetTotalRecordsForTable1<T>()
    {
      DataContext dc = new DataContext ();
      return dc.GetTable<T>().Count();
    }
