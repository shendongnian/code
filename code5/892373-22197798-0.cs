    public static class Localization
    {
      public static string ToCultureString(this MyEnumType type)
      {
         return ResourceManager.GetString(type.ToString(), Culture);
      }
    }
