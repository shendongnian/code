    string[] x = { "1", "2", "0", ",", "1", "2", "1", ",", "1", "2", "2" };
    string all = string.Join("", x);
    string[] parts = all.Split(',');
    int i = int.MinValue;
    int[] y = parts
        .Where(s => int.TryParse(s.Trim(), out i))
        .Select(s => i)
        .ToArray();
