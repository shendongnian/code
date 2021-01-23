    string sample = "Mountain View XX,Lake"
    // option 1
    string removed = sample.Remove(14, 3);
    // option 2
    string replaced = sample.Replace("XX,", String.Empty);
    // option 3
    string[] parts = sample.Split(',');
    parts[0] = parts[0].Substring(0, 14);
    string concatenated = String.Concat(parts);
