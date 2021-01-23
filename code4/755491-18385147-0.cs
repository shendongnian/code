    Dictionary<DateTime, List<Double>> map;
    foreach (var pair in map) {
      foreach (double value in pair.Value) {
        DateTime dt = pair.Key;
        // Now you have the DateTime and Double values
      }
    }
