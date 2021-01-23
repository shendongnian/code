    var ordered = list.OrderByDescending(x => x.All(char.IsDigit))
     .ThenByDescending(x=> x.Any(char.IsLetter))
     .ThenByDescending(x=> x.All(Char.IsSymbol))
     .ThenBy(x=>x)
     .ToList();
