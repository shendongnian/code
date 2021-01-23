    myList.FirstOrDefault(
        c => Are.SameIgnoringCase(
                 c.InternalName, 
                 internalName));
    public static class Are {
      public boolean SameIgnoringCase(string a, string b)
      {
        return string.Equals(a, b, StringComparison.OrdinalIgnoreCase);
      }
    }
