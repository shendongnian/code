    var people = new[] { "Arthur", "Bertha", "Cristobal", "Dolly", "Edouard" };
    var indices = Enumerable.Range(0, people.Length);
    var result = Enumerable
      .Range(1, people.Length - 1)
      .SelectMany(i => indices.Combinations(i))
      .Where(IsValidCombination)
      .Select(combination => combination.Select(i => people[i]));
