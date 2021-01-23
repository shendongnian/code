    public static class StringMore
    {
    //You might want to use conditional statements to mark this as obsolete in 4.0 or higher
      public static string Join(string separator, IEnumerable<string> values)
      {
        if (values == null)
          throw new ArgumentNullException("values");
        if (separator == null)
          separator = string.Empty;
        using (IEnumerator<string> en = values.GetEnumerator())
        {
          if (!en.MoveNext())
            return "";
          StringBuilder sb = new StringBuilder(en.Current);
          while(en.MoveNext())
          {
            stringBuilder.Append(separator);
            stringBuilder.Append(en.Current);
          }
          return sb.ToString();
        }
      }
      public static string Join<T>(string separator, IEnumerable<T> values)
      {
        if (values == null)
          throw new ArgumentNullException("values");
        if (separator == null)
          separator = string.Empty;
        using (IEnumerator<string> en = values.GetEnumerator())
        {
          if (!en.MoveNext())
            return "";
          T cur = en.Current;
          StringBuilder sb = cur == null ? new StringBuilder() : new StringBuilder(cur.ToString());
          while(en.MoveNext())
          {
            stringBuilder.Append(separator);
            cur = en.Current;
            if(cur != null)
              stringBuilder.Append(cur.ToString());
          }
          return sb.ToString();
        }
      }
    }
