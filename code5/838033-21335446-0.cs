    public static class Extention
    {
      public static string Translate(this string strName, string locale)
      {
          return NSBundle.FromPath(NSBundle.MainBundle.PathForResource(locale, "lproj")).LocalizedString(strName,"","");
      }  
    }
