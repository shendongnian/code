    string[] text = System.IO.File.ReadAllLines(file);
    var thirtyLineSections = text
        .Select((line, index) => new { line, group = index / 30 })
        .GroupBy(item => item.group)
        .ToArray();
    int textboxIndex = 0;
    foreach (var section in thirtyLineSections)
    {
        string textForSection = string.Join(",",
            section.Select(item => item.line).ToArray()); // see note below
        textboxes[textboxIndex].Text = textForSection;
        textboxIndex++;
    }
