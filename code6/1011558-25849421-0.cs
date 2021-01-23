    List<string> valid_words = new List<string>();
    foreach (string sentence in processedSentencesList)
    {
      foreach (string entity in entityString)
      {
        if (sentence.Contains(entity))
        {
          valid_words.Add(entity);
        }
      }
    }
