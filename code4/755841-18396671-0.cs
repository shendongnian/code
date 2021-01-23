    // Enumerate by nearest space
    // Split String value by closest to length spaces
    // e.g. for length = 3 
    // "abcd efghihjkl m n p qrstsf" -> "abcd", "efghihjkl", "m n", "p", "qrstsf" 
    public static IEnumerable<String> EnumByNearestSpace(this String value, int length) {
      if (String.IsNullOrEmpty(value))
        yield break;
    
      int bestDelta = int.MaxValue;
      int bestSplit = -1;
    
      int from = 0;
    
      for (int i = 0; i < value.Length; ++i) {
        var Ch = value[i];
    
        if (Ch != ' ')
          continue;
    
        int size = (i - from);
        int delta = (size - length > 0) ? size - length : length - size;
    
        if ((bestSplit < 0) || (delta < bestDelta)) {
          bestSplit = i;
          bestDelta = delta;
        }
        else {
          yield return value.Substring(from, bestSplit - from);
    
          i = bestSplit;
    
          from = i + 1;
          bestSplit = -1;
          bestDelta = int.MaxValue;
        }
      }
    
      // String's tail
      if (from < value.Length) {
        if (bestSplit >= 0) {
          if (bestDelta < value.Length - from)
            yield return value.Substring(from, bestSplit - from);
    
          from = bestSplit + 1;
        }
    
        if (from < value.Length)
          yield return value.Substring(from);
      }
    }
    ...
    var list = data.EnumByNearestSpace(150).ToList();
