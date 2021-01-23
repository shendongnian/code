    public static bool Match(string s) {
      return (s.Length == 8) &&
             (s.Where(Char.IsDigit).Count() == 7) &&
             (s.Where(Char.IsLetter).Count() == 1);
    }
