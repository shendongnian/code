    for (int i = 0; i < values.Count; ++i)
    {
      for (int j = 0; j < values.Count; ++j)
      {
        if (i != j && ((values[i] & values[j]) != 0))
            throw new Exception(...);
      }
    }
