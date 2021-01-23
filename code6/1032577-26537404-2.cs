    string DoReplacements(string body, Dictionary<string, string> replacements)
    {
      string[] parts = body.Split('~');
      // Start on the second element, with index 1, and increment the index by 2.
      for (int i = 1; i < parts.Length; i += 2)
        replacements.TryGetValue(parts[i], out parts[i]);
      // Put it all back together.
      return string.Concat(parts);
    }
