    class Widget
    {
      public Widget ( string category , IEnumerable<string> subcategories )
      {
        this.Category      = category ;
        this.Subcategories = subcategories.ToArray() ;
      }
      public string Category { get; private set; }
      public string[] Subcategories { get ; private set ; }
    }
