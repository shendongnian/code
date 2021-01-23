    // Get the indexes for of the array
    var ys = Enumerable.Range(0, winningCombinations.GetLength(0));
    var xs = Enumerable.Range(0, winningCombinations.GetLength(1));
    // Select the values at each index, becomes a collection of collections
    var vals = ys.Select(y => xs.Select(x => this.contentOf(winningCombinations[y, x]));
    // Discover whether at least one of the sets has exactly one value contained.
    return vals.Any(c => !x.Distinct().Skip(1).Any())
