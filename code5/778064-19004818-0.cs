    static bool HitEnd(this MatchCollection matches, string input) {
      if (matches.Count == 0) {
        return false; // No matches at all
      }
      var lastMatch = matches.Cast<Match>().Last();
      return input.Length == (lastMatch.Index + lastMatch.Length)
    }
