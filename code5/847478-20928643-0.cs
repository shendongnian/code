    public static string Rotate(this string s, int numberOfChars)
    {
      if (string.IsNullOrEmpty(s))
        return s;
      numberOfChars %= s.Length;
      if (numberOfChars == 0)
        return s;
      if (numberOfChars < 0)
        numberOfChars += s.Length;
      return s.Substring(numberOfChars) + s.Remove(numberOfChars);
    }
