    string sample = "Mountain View 123,Lake"
    // option 1; remove digits followed by a comma
    string replaced = Regex.Replace(sample, "\d+,", String.Empty);
    // option 2; remove what's after the last space in the part before the comma
    string[] parts = sample.Split(',');
    parts[0] = parts[0].Substring(0, parts[0].LastIndexOf(" ") + 1);
    string concatenated = String.Concat(parts);
