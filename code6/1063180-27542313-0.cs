    public static bool ContainsKeyInsensitive(this Dictionary<char, ...> dict, char c)
    {
      foreach (var k in dict.Keys)
      {
        if (char.ToLower(k) == char.ToLower(c)))
        {
          return true;
        }
      }
      return false;
    }
