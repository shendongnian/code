    String[] colors = {"green", "red", "blue", "brown"};
    string s = "e";
    var query = colors.Where(c => c.Contains(s)).ToArray();
    s = "n";
    query = query.Where(c=> c.Contains("n"));
    Console.WriteLine(query.Count());
