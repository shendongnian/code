    public static string EncodeNonAsciiCharacters(string value)
    {
      return Regex.Replace(
        value,
        @"[^\x00-\x7F]",
        m => String.Format("\\u{0:X4}", (int)m.Value[0]));
    }
