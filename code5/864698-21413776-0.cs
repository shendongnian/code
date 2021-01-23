    private string[][] Work(string hs_get_text) {
      var lines = hs_get_text.Split('\n');
      int linesLength = lines.Length;
      var pairs = new List<string[]>(linesLength);
      foreach (var line in lines) {
        pairs.Add(line.Split(','));
      }
      return pairs.ToArray();
    }
