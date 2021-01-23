    public static class SelectListExtensions
    {
       public static SelectList ToSelectList<T>(this IEnumerable<T> items, string dataValueField, string dataTextField) where T : class
       {
          return new SelectList(items, dataValueField, dataTextField);
       }
    }
