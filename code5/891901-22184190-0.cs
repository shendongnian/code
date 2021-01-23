    var userInput = "doaurid";
    var toCheck = "dad";
    var check = toCheck.GroupBy(c=> c).ToDictionary(g => g.Key, g => g.Count());
    var input = userInput.GroupBy(c=> c).ToDictionary(g => g.Key, g => g.Count());
    bool validMatch = check.All(g => input.ContainsKey(g.Key) && input[g.Key] == g.Value);
