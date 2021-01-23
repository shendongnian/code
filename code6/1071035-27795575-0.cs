    public static List<object> findType<TTarget>()
    {
      List<object> items = new List<object>();
      foreach (KeyValuePair<int, object> entry in DataSource.ItemPairs)
      {
        if (entry.Value != null && entry.Value is TTarget)
        {
           …
