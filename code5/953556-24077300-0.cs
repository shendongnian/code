    myList.FirstOrDefault(
        c => StrUtils.SameNoCase(
                 c.InternalName, 
                 internalName));
    public static class StrUtils{
      public boolean SameNoCase(string a, string b)
      {
        return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
      }
    }
