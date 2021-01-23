    public static IEnumerable<int> GetIndexOfEvery(string haystack, string needle)
    {
      int index;
      int pos = 0;
      string s = haystack;
    
      while((index = s.IndexOf(needle)) != -1)
      {              
          yield return index + pos;
          pos = pos + index + 1;
          s = haystack.Substring(pos);
      }
    }
