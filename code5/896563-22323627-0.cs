    Dictionary<char, List<string>> input = new Dictionary<char, List<string>>();
    input.Add('A', new List<string>() { "A1", "A2", "A3", "A4" });
    input.Add('B', new List<string>() { "B1", "B2", "B3", "B4", "B5" });
    input.Add('C', new List<string>() { "C1", "C2", "C3" });
    input.Add('D', new List<string>() { "D1", "D2" });
    
    input = input.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);
