    var ret = rs.OfType<DictionaryEntry>()
      .Where(x => x.Key.ToString().StartsWith("Title"))
      .ToDictionary(
        k => k.Value.ToString(),
        v => rs.OfType<DictionaryEntry>()
          .Where(x => x.Key.ToString().StartsWith(v.Key.ToString().Replace("Title", "")))
          .ToDictionary(
            x => x.Value.ToString().Split('?')[0] + "?",
            x => x.Value.ToString().Split('?')[1]
          )
      );
