    public static string Contacts<TContact>(AppContext ctx, List<TContact> list )
        where TContact : IContact
    {
      foreach (TContact element in list)
      {
        // do some db work
      }
    }
