    var input = "1000|2014|01|AP|1|00000001|00";
    
    var pattern = new int[] {4, 4, 2, 2, 1, 8, 2};
    
    // Check each element length according to it's input position.
    var matches = input
         .Split('|')
          // Get only those elements that satisfy the length condition.
         .Where((x, index) => x.Count() == pattern(index))
         .Count();
    
    if (matches == pattern.Count())
        // Input was as expected.
