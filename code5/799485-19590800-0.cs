    public static class FrameworkElementExtensions
    {
      public static Object TryFindResourceEx(this FrameworkElement el, Object resourceKey)
      {
        var result = el.FindResource(resourceKey);
    
        if(result == null)
        {
          // fallback handling here
        }
    
        return result;
      }
    }
