    public static class HelperClass {
      public static object GetProperty(this object source, string name) {
         if (source == null) return null;
         var pi = source.GetType().GetProperty(name);
         if (pi == null) return null;
         return pi.GetValue(source);
      }
    }
