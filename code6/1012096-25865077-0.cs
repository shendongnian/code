      int[] numbers = new [] { 2, 1, 2, 1, 5, 6, 5 };
      int toFind = 5;
  
      // all indexes of "5" {4, 6}
      int[] indexes = numbers
        .Select((v, i) => new {
          value = v,
          index = i
        })
        .Where(pair => pair.value == toFind)
        .Select(pair => pair.index)
        .ToArray();
